namespace _Project_CheatSheet.Controllers.Resources.Service
{
    using _Project_CheatSheet.Controllers.Resources.Models;
    using _Project_CheatSheet.Data;
    using _Project_CheatSheet.Data.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Security.Claims;
    using IResourceService = Interfaces.IResourceService;

    public class ResourceService : ApiController, IResourceService
    {

        private readonly CheatSheetDbContext context;
        private readonly UserManager<User> userManager;
        private readonly IHttpContextAccessor httpContextAccessor;

        public ResourceService(CheatSheetDbContext context,
                             UserManager<User> userManager,
                             IHttpContextAccessor httpContextAccessor)
        {
            this.context = context;
            this.userManager = userManager;
            this.httpContextAccessor = httpContextAccessor;
        }


 
        [HttpPost]

        public async Task<Resource> addResource(ResourceAddModel resourceModel)
        {
            Resource resource = new Resource()
            {
                Content = resourceModel.Content,
                CreateDate = DateTime.Now,
                Title = resourceModel.Title,
                ImageUrl = resourceModel.ImageUrl,
                UserId = getUserId(),
                Categories = resourceModel.Categories
            };

            await context.Resources.AddAsync(resource);
            await context.SaveChangesAsync();
            return resource;
        }


        [HttpGet]

        public async Task<IEnumerable<ResourceModel>> myResources()
        {

            string userId = getUserId();

            IEnumerable<ResourceModel> resources = await context.Resources.Include(res => res.User)
                .Select(res => new ResourceModel()
                {
                    Id = res.Id.ToString(),
                    Content = res.Content,
                    ImageUrl = res.ImageUrl,
                    Title = res.Title,
                    CategoryNames = res.Categories.Select(c => c.Name),
                    UserId = res.User.Id,
                })
                .Where(res => res.UserId == userId)
                .ToArrayAsync();

            return resources;
        }

        [HttpGet]
        public async Task<IEnumerable<ResourceModel>> publicResources()
        {
            IEnumerable<ResourceModel> models = await context.Resources.Include(res => res.Categories)
                .AsNoTracking()
                .Select(res => new ResourceModel()
                {
                    Id = res.Id.ToString(),
                    Content = res.Content,
                    ImageUrl = res.ImageUrl,
                    Title = res.Title,
                    CategoryNames = res.Categories.Select(c => c.Name),
                    UserName = res.User.UserName,
                    DateTime = res.CreateDate.ToString("dd/MM/yy")
                })
                .Where(c => c.CategoryNames.Contains("Public")).ToArrayAsync();

            return models;
        }


        [HttpGet]
        public async Task<ResourceModel> resourceById(string? resourceId)
        {
            IEnumerable<ResourceModel?> resources = await context.Resources.Include(res => res.Categories)
                .Select(r => new ResourceModel()
                {
                    Id = r.Id.ToString(),
                    CategoryNames = r.Categories.Select(c => c.Name),
                    Content = r.Content,
                    DateTime = r.CreateDate.ToString(),
                    ImageUrl = r.ImageUrl,
                    Title = r.Title,
                    UserId = r.UserId.ToString(),
                }).Where(x=>x.Id == resourceId).ToArrayAsync();

            if (resources.Count() == 0)
            {
                return null;
            }
            if (resources.Any(r => r.CategoryNames.Contains("Public") || resources.Any(r=>r.UserId==getUserId())))
            {
                ResourceModel? resource = resources.FirstOrDefault(x => x.Id.ToLower() == resourceId.ToLower());
                return resource;
            }

            Console.WriteLine("Entered here!");
            return null;
        }

        private string getUserId()
        {
            return httpContextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
