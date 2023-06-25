namespace _Project_CheatSheet.Features.Resources.Services
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Common.GlobalConstants.Resource;
    using Common.Pagination;
    using Common.UserService.Interfaces;
    using Infrastructure.Data;
    using Infrastructure.Data.Models;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class ResourceService : IResourceService
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


        public async Task<string> AddResources(ResourceAddModel resourceModel)
        {
            if (resourceModel == null)
            {
                throw new Exception( ResourceMessages.SuchModelDoesNotExist);
            }

            var isNull = resourceModel
                .GetType()
                .GetProperties()
                .Any(p => p.GetValue(resourceModel) == null);

            if (isNull || resourceModel.CategoryIds.Count == 0)
            {
                throw new Exception(ResourceMessages.OnUnsuccessfulResourceAdd);
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
                await context.SaveChangesAsync();
            }

            return ResourceMessages.OnSuccessfulResourceAdd;
        }


        public async Task<IEnumerable<ResourceModel>> GetMyResources()
        {
            var userId = currentUserService.GetUserId();

            IEnumerable<ResourceModel> resources = await context.Resources
                .AsNoTracking()
                .Include(res => res.CategoryResources)
                .Include(res => res.User)
                .ProjectTo<ResourceModel>(mapper.ConfigurationProvider)
                .Where(res => res.UserId == userId)
                .ToArrayAsync();

            return resources;
        }


        public async Task<Pagination<ResourceModel>> GetPublicResources(int pageNumber)
        {
            var userId = currentUserService.GetUserId();

            var resourcesCount =
                await context.Resources.Where(r => r.IsPublic == true || r.UserId == userId).CountAsync();

            var resourceModels = context.Resources
                .Include(res => res.CategoryResources)
                .Include(res => res.User)
                .Where(c => c.IsPublic == true || c.UserId == userId)
                .ProjectTo<ResourceModel>(mapper.ConfigurationProvider);

            var paginatedModels = await Pagination<ResourceModel>.CreateAsync(resourceModels, pageNumber);

            return paginatedModels;
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
            var userId = currentUserService.GetUserId();
            var pages = (double)context.Resources.Where(r => r.IsPublic || r.UserId == userId).CountAsync().Result /
                        ResourcesPerPage;
            var totalPages = (int)Math.Ceiling(pages);
            return totalPages;
        }

        public async Task<string> EditResource(string id, ResourceEditModel resourceEdit)
        {
            var resource = await context.Resources.FindAsync(Guid.Parse(id));
            if (resource == null)
            {
                throw new Exception(ResourceMessages.SuchModelDoesNotExist);
            }

            context.Entry(resource).CurrentValues.SetValues(resourceEdit);
            try
            {
                await context.SaveChangesAsync();
                return ResourceMessages.OnSuccessfulResourceEdit;
            }
            catch (DbUpdateException)
            {
                throw new Exception(ResourceMessages.OnUnsuccessfulResourceEdit);
            }
        }

        public async Task<string> RemoveResource(string id)
        {
            var userId = currentUserService.GetUserId();
            var resource = await context.Resources.FindAsync(Guid.Parse(id));

            if (resource == null)
            {
                throw new Exception(ResourceMessages.SuchModelDoesNotExist);
            }
            if (resource.UserId != userId || resource.IsDeleted)
            {
                throw new Exception(ResourceMessages.OnUnsuccessfulResourceRemove);
            }

            context.Remove(resource);
            await context.SaveChangesAsync();
            return ResourceMessages.OnSuccessfulResourceRemove;
        }
    }
}