﻿namespace _Project_CheatSheet.Controllers.Resources.Service
{
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
        private readonly IHttpContextAccessor httpContextAccessor;

        public ResourceService(CheatSheetDbContext context,
                             UserManager<User> userManager,
                             IHttpContextAccessor httpContextAccessor)
        {
            this.context = context;
            this.userManager = userManager;
            this.httpContextAccessor = httpContextAccessor;
        }



        public async Task<StatusCodeResult> addResource(ResourceAddModel resourceModel)
        {
            if (resourceModel == null)
            {
                return StatusCode(StatusCodes.Status403Forbidden);

            }

            bool isNull = resourceModel.GetType().GetProperties()
            .Any(p => p.GetValue(resourceModel) == null);
            if (isNull)
            {
                return StatusCode(StatusCodes.Status403Forbidden);
            }

            Resource resource = new Resource()
            {
                Content = resourceModel.Content,
                CreateDate = DateTime.Now,
                Title = resourceModel.Title,
                ImageUrl = resourceModel.ImageUrl,
                UserId = getUserId(),
                CategoryResources = resourceModel.CategoryResources,
            };
            
            

            await context.Resources.AddAsync(resource);
            await context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
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
                    CategoryNames = res.CategoryResources.Select(c => c.Category.Name),
                    UserId = res.User.Id,
                })
                .Where(res => res.UserId == userId)
                .ToArrayAsync();

            return resources;
        }

        [HttpGet]
        public async Task<IEnumerable<ResourceModel>> publicResources()
        {
            IEnumerable<ResourceModel> models = await context.Resources.Include(res => res.CategoryResources)
                .AsNoTracking()
                .Select(res => new ResourceModel()
                {
                    Id = res.Id.ToString(),
                    Content = res.Content,
                    ImageUrl = res.ImageUrl,
                    Title = res.Title,
                    CategoryNames = res.CategoryResources.Select(c => c.Category.Name),
                    UserName = res.User.UserName,
                    DateTime = res.CreateDate.ToString("dd/MM/yy"),
                    UserId=res.UserId
                })
                .Where(c => c.CategoryNames.Contains("Public")||c.UserId==getUserId()).ToArrayAsync();

            return models;
        }


        [HttpGet]
        public async Task<ResourceModel> resourceById(string? resourceId)
        {
            IEnumerable<DetailResources?> resources = await context.Resources.Include(res => res.CategoryResources)
                .Include(res => res.Comments)
                .Select(r => new DetailResources()
                {
                    Id = r.UserId.ToString(),
                    CategoryNames = r.CategoryResources.Select(c => c.Category.Name),
                    Content = r.Content,
                    DateTime = r.CreateDate.ToString(),
                    ImageUrl = r.ImageUrl,
                    Title = r.Title,
                    UserId = r.UserId.ToString(),
                    Comments = r.Comments,
                    UserName = r.User.UserName,
                    Likes=r.Likes.Count,

                    CommentContent=r.Comments.Select(x=>x.CommentLikes.Select(cl=>cl.Comment)),
                    CommentLikes=r.Comments.Select(x=>x.CommentLikes.Count),


                }).Where(x => x.Id == resourceId).ToArrayAsync();

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
