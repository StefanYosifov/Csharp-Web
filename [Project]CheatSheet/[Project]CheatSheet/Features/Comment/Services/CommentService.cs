﻿namespace _Project_CheatSheet.Features.Comment.Services
{
    using _Project_CheatSheet.Data;
    using _Project_CheatSheet.Data.Models;
    using _Project_CheatSheet.Features.Comment.Interfaces;
    using _Project_CheatSheet.Features.Comment.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class CommentService : ICommentService
    {

        private readonly CheatSheetDbContext context;
        private readonly UserManager<User> userManager;
        private readonly IHttpContextAccessor httpContextAccessor;

        public CommentService(CheatSheetDbContext context, UserManager<User> userManager,IHttpContextAccessor httpContextAccessor)
        {
            this.context = context;
            this.userManager = userManager;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<StatusCodeResult> createAComment(CommentModel comment)
        {
            if(comment==null)
            {
                return new StatusCodeResult(StatusCodes.Status400BadRequest);
            }

            var user = GetUser();
            Console.WriteLine(user.Result.UserName);
            Console.WriteLine(comment.Id);
            if (user == null)
            {
                return new StatusCodeResult(StatusCodes.Status403Forbidden);
            }
            var resource = GetResource(comment.ResourceId);
            if(resource == null)
            {
                return new StatusCodeResult(StatusCodes.Status403Forbidden);
            }

            Comment dbComment = new Comment()
            { 
                UserId = user.Result.Id,
                Content = comment.Content,
                ResourceId = Guid.Parse(comment.ResourceId.ToString()),  
                CreatedAt = DateTime.Now,
            };

            await context.Comments.AddAsync(dbComment);
            await context.SaveChangesAsync();
            return new StatusCodeResult(StatusCodes.Status201Created);
        }

        public async Task<IEnumerable<CommentModel>> getCommentsFromResource(string resourceId)
        {
            if (resourceId.Length != 36)
            {
                return Enumerable.Empty<CommentModel>();
            }

            IEnumerable<CommentModel> comments=await context.Comments
                .OrderBy(c=>c.CreatedAt)
                .Select(c=>new CommentModel()
            {
                Id=c.Id.ToString(),
                Content=c.Content,
                CreatedAt=c.CreatedAt.ToString(ModelConstants.dateFormatter),
                ResourceId=c.ResourceId.ToString(),
                UserName=c.User.UserName,
                UserProfileImage=c.User.ProfilePictureUrl,
            }).ToArrayAsync();

            return comments;
        }

        private async Task<User> GetUser()
        {
            var id=httpContextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return await context.Users.FirstOrDefaultAsync(u=>u.Id==id);
        }

        private async Task<Resource> GetResource(string resourceId)
        {
            var resource = await context.Resources.FindAsync(resourceId);
            return resource;
        }
    }
}