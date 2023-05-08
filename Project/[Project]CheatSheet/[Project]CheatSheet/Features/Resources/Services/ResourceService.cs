namespace _Project_CheatSheet.Controllers.Resources.Service
{
    using _Project_CheatSheet.Common.CurrentUser.Interfaces;
    using _Project_CheatSheet.Common.ModelConstants;
    using _Project_CheatSheet.Controllers.Resources.Models;
    using _Project_CheatSheet.Data;
    using _Project_CheatSheet.Data.Models;
    using _Project_CheatSheet.Features.Resources.Models;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using IResourceService = Interfaces.IResourceService;

    public class ResourceService : ApiController, IResourceService
    {

        private readonly CheatSheetDbContext context;
        private readonly IMapper mapper;
        private readonly ICurrentUser currentUserService;
        private const int resourcesPerPage = 12;

        public ResourceService(CheatSheetDbContext context,
                             IMapper mapper,
                             ICurrentUser currentUserService)
        {
            this.context = context;
            this.mapper = mapper;
            this.currentUserService = currentUserService;
        }

        [HttpPost]
        public async Task<StatusCodeResult> AddResources(ResourceAddModel resourceModel)
        {

            if (resourceModel == null)
            {
                return StatusCode(StatusCodes.Status403Forbidden);
            }

            bool isNull = resourceModel
            .GetType()
            .GetProperties()
            .Any(p => p.GetValue(resourceModel) == null);

            if (isNull || resourceModel.CategoryIds.Count==0)
            {
                return StatusCode(StatusCodes.Status403Forbidden);
            }

            string userId = currentUserService.GetUserId();

            Resource resource = new Resource()
            {
                Content = resourceModel.Content,
                CreatedAt = DateTime.Now,
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
                CategoryResource categoryResource = new CategoryResource()
                {
                    CategoryId = category.Id,
                    ResourceId = resource.Id
                };
                await context.CategoriesResources.AddAsync(categoryResource);
                context.SaveChanges();
            }
            return StatusCode(StatusCodes.Status201Created);
        }


        [HttpGet("getMy")]
        public async Task<IEnumerable<ResourceModel>> GetMyResources()
        {
            string userId = currentUserService.GetUserId();

            IEnumerable<ResourceModel> resources = await context.Resources
                .Include(res => res.CategoryResources)
                .Include(res => res.User)
                .ProjectTo<ResourceModel>(mapper.ConfigurationProvider)
                .Where(res => res.UserId == userId)
                .ToArrayAsync();

            return resources;
        }

        [HttpGet("getPublic")]

        public async Task<IEnumerable<ResourceModel>> GetPublicResources(int pageNumber)
        {
            pageNumber = pageNumber - 1;
            string userId = currentUserService.GetUserId();

            //12*1=12-12=0
            int resourcesToSkip = (pageNumber * resourcesPerPage)-pageNumber;
            int resourcesCount = await context.Resources.CountAsync();

            if (resourcesToSkip > resourcesCount || pageNumber<0)
            {
                return Enumerable.Empty<ResourceModel>();
            }

            //45 = 3*12=32 
            int resourcesToTake = 
                resourcesCount - (pageNumber*resourcesPerPage)>resourcesPerPage
                ?resourcesToTake=resourcesPerPage
                : resourcesToTake = resourcesCount - (pageNumber * resourcesPerPage);
            Console.WriteLine($"{resourcesToSkip} {resourcesToTake}");

            IEnumerable<ResourceModel> models = await context.Resources
                .Include(res => res.CategoryResources)
                .Include(res => res.User)
                .ProjectTo<ResourceModel>(mapper.ConfigurationProvider)
                .Where(c => c.CategoryNames!.Contains("Public")||c.UserId== userId)
                .Skip(resourcesToSkip)
                .Take(resourcesToTake)
                .ToArrayAsync();

            return models;
        }
        [HttpGet("getById")]

        public async Task<DetailResources> GetResourceById(string? resourceId)
        {
            IEnumerable<DetailResources> details = await context.Resources
                .Include(r=>r.User)
                .Include(r=>r.Comments)
                .ProjectTo<DetailResources>(mapper.ConfigurationProvider)
                .Where(r=>r.Id==resourceId).ToListAsync();

            string userId = currentUserService.GetUserId();
            
            var detailResource=details
                .FirstOrDefault(x=>x.CategoryNames.Any(cn=>cn.Contains("Public")) || details.Any(x=>x.UserId==userId));
            
            if (detailResource.ResourceLikes.Any(rl => rl.UserId == userId))
            {
                detailResource.HasLiked = true;
            }
            return detailResource;
        }

        public async Task<int> GetTotalPage()
        {
            double pages=(double)context.Resources.CountAsync().Result/resourcesPerPage;
            int totalPages=(int)Math.Ceiling(pages);
            return totalPages;
        }
    }
}
