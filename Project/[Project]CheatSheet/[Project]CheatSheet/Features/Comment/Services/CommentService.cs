namespace _Project_CheatSheet.Features.Comment.Services
{
    using _Project_CheatSheet.Common.CurrentUser.Interfaces;
    using _Project_CheatSheet.Common.ModelConstants;
    using _Project_CheatSheet.Data;
    using _Project_CheatSheet.Data.Models;
    using _Project_CheatSheet.Features.Comment.Interfaces;
    using _Project_CheatSheet.Features.Comment.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CommentService : ICommentService
    {

        private readonly CheatSheetDbContext context;
        private readonly UserManager<User> userManager;
        private readonly ICurrentUser currentUserService;

        public CommentService(CheatSheetDbContext context, 
                              UserManager<User> userManager,
                              ICurrentUser currentUserService)
        {
            this.context = context;
            this.userManager = userManager;
            this.currentUserService = currentUserService;
        }

        public async Task<StatusCodeResult> createAComment(CommentModel comment)
        {
            if(comment==null)
            {
                return new StatusCodeResult(StatusCodes.Status400BadRequest);
            }

            var user = await currentUserService.GetUser();
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
                UserId = user.Id,
                Content = comment.Content,
                ResourceId = Guid.Parse(comment.ResourceId.ToString()),  
                CreatedOn = DateTime.Now,
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

            var userId = currentUserService.GetUserId();

            IEnumerable<CommentModel> comments = await context.Comments
                .OrderBy(c => c.CreatedOn)
                .Select(c => new CommentModel()
                {
                    Id = c.Id.ToString(),
                    Content = c.Content,
                    CreatedAt = c.CreatedOn.ToString(ModelConstants.dateFormatter),
                    ResourceId = c.ResourceId.ToString(),
                    UserName = c.User.UserName,
                    UserProfileImage = c.User.ProfilePictureUrl,
                    CommentLikes = c.CommentLikes,
                    HasLiked = c.CommentLikes.Select(cl => cl.UserId).Any(c=>c==userId)
                }).Where(c => c.ResourceId == resourceId).ToArrayAsync();

            return comments;
        }

        private async Task<Resource> GetResource(string resourceId)
        {
            var resource = await context.Resources.FindAsync(resourceId);
            return resource;
        }
    }
}
