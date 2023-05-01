namespace _Project_CheatSheet.Controllers.Resources.Service
{
    using _Project_CheatSheet.Common.CurrentUser.Interfaces;
    using _Project_CheatSheet.Common.ModelConstants;
    using _Project_CheatSheet.Controllers.Resources.Models;
    using _Project_CheatSheet.Data;
    using _Project_CheatSheet.Data.Models;
    using _Project_CheatSheet.Features.Resources.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Security.Claims;
    using IResourceService = Interfaces.IResourceService;

    public class ResourceService : ApiController, IResourceService
    {

        private readonly CheatSheetDbContext context;
        private readonly UserManager<User> userManager;
        private readonly ICurrentUser currentUserService;

        

        public ResourceService(CheatSheetDbContext context,
                             UserManager<User> userManager,
                             ICurrentUser currentUserService)
        {
            this.context = context;
            this.userManager = userManager;
            this.currentUserService = currentUserService;
        }



        public async Task<StatusCodeResult> addResource(ResourceAddModel resourceModel)
        {
            if (resourceModel == null)
            {
                return StatusCode(StatusCodes.Status403Forbidden);
            }

            bool isNull = resourceModel.GetType().GetProperties()
            .Any(p => p.GetValue(resourceModel) == null);
            if (isNull || resourceModel.CategoryIds.Count==0)
            {
                return StatusCode(StatusCodes.Status403Forbidden);
            }

            string userId = await currentUserService.GetUserId();

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

        public async Task<IEnumerable<ResourceModel>> myResources()
        {

            string userId = await currentUserService.GetUserId();

            IEnumerable<ResourceModel> resources = await context.Resources.Include(res => res.User)
                .Select(res => new ResourceModel()
                {
                    Id = res.Id.ToString(),
                    Content = res.Content,
                    ImageUrl = res.ImageUrl,
                    Title = res.Title,
                    CategoryNames = res.CategoryResources.Select(c => c.Category.Name),
                    UserId = res.User.Id,
                })
                .Where(res => res.UserId == userId)
                .ToArrayAsync();

            return resources;
        }

        public async Task<IEnumerable<ResourceModel>> publicResources()
        {

            string userId = await currentUserService.GetUserId();

            IEnumerable<ResourceModel> models = await context.Resources
                .Include(res => res.CategoryResources)
                .Include(res => res.User)
                .AsNoTracking()
               .Select(r => new ResourceModel()
               {
                   Id = r.Id.ToString(),
                   Title = r.Title,
                   Content = r.Content,
                   DateTime = r.CreatedAt.ToString(ModelConstants.dateFormatter),
                   ImageUrl = r.ImageUrl,
                   UserId = r.User.Id,
                   UserName = r.User.UserName,
                   CategoryNames = r.CategoryResources.Select(c => c.Category.Name),
               })
                .Where(c => c.CategoryNames!.Contains("Public")||c.UserId== userId).ToArrayAsync();

            return models;
        }

  
        public async Task<DetailResources> resourceById(string? resourceId)
        {
            IEnumerable<DetailResources> details = await context.Resources
                .Include(r=>r.User)
                .Include(r=>r.Comments)
                 .Select(r => new DetailResources()
                 {
                     Id = r.Id.ToString(),
                     Content = r.Content,
                     DateTime = r.CreatedAt.ToString(),
                     ImageUrl = r.ImageUrl,
                     Title = r.Title,
                     UserId = r.UserId,
                     UserName = r.User.UserName,
                     UserImage = r.User.ProfilePictureUrl,
                     Likes = r.ResourceLikes.Count,
                     CategoryNames=r.CategoryResources.Select(c => c.Category.Name),
                 }).Where(r=>r.Id==resourceId).ToListAsync();


            string userId = await currentUserService.GetUserId();

            return details
            .Where(x=>x.CategoryNames.Any(cn=>cn=="Public" || details.Any(x=>x.UserId.ToLower()==userId.ToLower())))
            .FirstOrDefault()!;

        }
    }
}
