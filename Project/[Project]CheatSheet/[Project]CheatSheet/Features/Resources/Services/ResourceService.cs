using _Project_CheatSheet.Common.CurrentUser.Interfaces;
using _Project_CheatSheet.Data;
using _Project_CheatSheet.Data.Models;
using _Project_CheatSheet.Features.Resources.Interfaces;
using _Project_CheatSheet.Features.Resources.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _Project_CheatSheet.Features.Resources.Services
{
    public class ResourceService :  IResourceService
    {
        private const int ResourcesPerPage = 12;

        private readonly CheatSheetDbContext context;
        private readonly ICurrentUser currentUserService;
        private readonly IMapper mapper;

        public ResourceService(
            CheatSheetDbContext context,
            IMapper mapper,
            ICurrentUser currentUserService)
        {
            this.context = context;
            this.mapper = mapper;
            this.currentUserService = currentUserService;
        }

      
        public async Task<ResourceAddModel> AddResources(ResourceAddModel resourceModel)
        {
            if (resourceModel == null)
            {
                return null;
            }

            var isNull = resourceModel
                .GetType()
                .GetProperties()
                .Any(p => p.GetValue(resourceModel) == null);

            if (isNull || resourceModel.CategoryIds.Count == 0)
            {
                return null;
            }

            var userId = currentUserService.GetUserId();

            var resource = new Resource
            {
                Content = resourceModel.Content,
                Title = resourceModel.Title,
                ImageUrl = resourceModel.ImageUrl,
                UserId = userId
            };

            var categories = await context.Categories
                .Where(c => resourceModel.CategoryIds.Contains(c.Id))
                .ToArrayAsync();

            await context.Resources.AddRangeAsync(resource);
            await context.SaveChangesAsync();
            foreach (var category in categories)
            {
                var categoryResource = new CategoryResource
                {
                    CategoryId = category.Id,
                    ResourceId = resource.Id
                };
                await context.CategoriesResources.AddAsync(categoryResource);
                context.SaveChangesAsync();
            }

            return resourceModel;
        }


      
        public async Task<IEnumerable<ResourceModel>> GetMyResources()
        {
            var userId = currentUserService.GetUserId();

            IEnumerable<ResourceModel> resources = await context.Resources
                .Include(res => res.CategoryResources)
                .Include(res => res.User)
                .ProjectTo<ResourceModel>(mapper.ConfigurationProvider)
                .Where(res => res.UserId == userId)
                .ToArrayAsync();

            return resources;
        }

     
        public async Task<IEnumerable<ResourceModel>> GetPublicResources(int pageNumber)
        {
            pageNumber = pageNumber - 1;
            var userId = currentUserService.GetUserId();

            //12*1=12-12=0
            var resourcesToSkip = pageNumber * ResourcesPerPage - pageNumber;
            var resourcesCount = await context.Resources.Where(r=>r.IsPublic==true || r.UserId==userId).CountAsync();

            if (resourcesToSkip > resourcesCount || pageNumber < 0)
            {
                return Enumerable.Empty<ResourceModel>();
            }

            //45 = 3*12=32 
            int resourcesToTake =
                resourcesCount - pageNumber * ResourcesPerPage > ResourcesPerPage
                    ? resourcesToTake = ResourcesPerPage
                    : resourcesToTake = resourcesCount - pageNumber * ResourcesPerPage;
            Console.WriteLine($"{resourcesToSkip} {resourcesToTake}");

            IEnumerable<ResourceModel> models = await context.Resources
                .Include(res => res.CategoryResources)
                .Include(res => res.User)
                .Where(c => c.IsPublic == true || c.UserId == userId)
                .ProjectTo<ResourceModel>(mapper.ConfigurationProvider)
                .Skip(resourcesToSkip)
                .Take(resourcesToTake)
                .ToArrayAsync();

            return models;
        }

      
        public async Task<DetailResources> GetResourceById(string? resourceId)
        {
            IEnumerable<DetailResources> details = await context.Resources
                .Include(r => r.User)
                .Include(r => r.Comments)
                .ProjectTo<DetailResources>(mapper.ConfigurationProvider)
                .Where(r => r.Id == resourceId).ToListAsync();

            var userId = currentUserService.GetUserId();

            var detailResource = details
                .FirstOrDefault(dr => dr.IsPublic || dr.UserId == userId);

            if (detailResource.ResourceLikes.Any(rl => rl.UserId == userId))
            {
                detailResource.HasLiked = true;
            }

            return detailResource;
        }

        public int GetTotalPage()
        {
            var userId=currentUserService.GetUserId();
            var pages = (double)  context.Resources.Where(r=>r.IsPublic || r.UserId==userId).CountAsync().Result / ResourcesPerPage;
            var totalPages = (int)Math.Ceiling(pages);
            return totalPages;
        }

        public async Task<ResourceEditModel> EditResource(string id, ResourceEditModel resourceEdit)
        {
            var resource = await context.Resources.FindAsync(Guid.Parse(id));
            if (resource == null)
            {
                return null;
            }

            context.Entry(resource).CurrentValues.SetValues(resourceEdit);
            try
            {
                await context.SaveChangesAsync();
                return resourceEdit;
            }
            catch (DbUpdateException)
            {
                return null!;
            }
        }

        public async Task<Resource> RemoveResource(string id)
        {
            string userId = currentUserService.GetUserId();
            var resource = await context.Resources.FindAsync(Guid.Parse(id));

            if (resource == null || resource.UserId != userId || resource.IsDeleted==true)
            {
                return null;
            }

            context.Remove(resource);
            await context.SaveChangesAsync();
            return resource;
        }
    }
}