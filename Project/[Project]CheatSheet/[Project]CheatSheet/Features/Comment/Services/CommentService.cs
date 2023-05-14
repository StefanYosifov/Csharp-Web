using _Project_CheatSheet.Common.CurrentUser.Interfaces;
using _Project_CheatSheet.Data;
using _Project_CheatSheet.Data.Models;
using _Project_CheatSheet.Features.Comment.Interfaces;
using _Project_CheatSheet.Features.Comment.Models;
using _Project_CheatSheet.GlobalConstants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _Project_CheatSheet.Features.Comment.Services
{
    public class CommentService : ICommentService
    {
        private readonly CheatSheetDbContext context;
        private readonly ICurrentUser currentUserService;

        public CommentService(
            CheatSheetDbContext context,
            ICurrentUser currentUserService)
        {
            this.context = context;
            this.currentUserService = currentUserService;
        }

        public async Task<StatusCodeResult> CreateAComment(CommentModel comment)
        {
            if (comment == null)
            {
                return new StatusCodeResult(StatusCodes.Status400BadRequest);
            }

            var user = await currentUserService.GetUser();
            if (user == null)
            {
                return new StatusCodeResult(StatusCodes.Status403Forbidden);
            }

            var resource = await GetResource(comment.ResourceId);
            if (resource == null)
            {
                return new StatusCodeResult(StatusCodes.Status403Forbidden);
            }

            var dbComment = new Data.Models.Comment
            {
                UserId = user.Id,
                Content = comment.Content,
                ResourceId = Guid.Parse(comment.ResourceId)
            };

            await context.Comments.AddAsync(dbComment);
            await context.SaveChangesAsync();
            return new StatusCodeResult(StatusCodes.Status201Created);
        }

        public async Task<EditCommentModel> EditComment(string id, EditCommentModel commentModel)
        {
            var currentUserId = currentUserService.GetUserId();
            var comment = await context.Comments.FindAsync(Guid.Parse(id));
            if (comment == null || comment.UserId != currentUserId)
            {
                return null;
            }

            context.Entry(comment).CurrentValues.SetValues(commentModel);
            try
            {
                await context.SaveChangesAsync();
                return commentModel;
            }
            catch (DbUpdateException)
            {
                return null!;
            }
        }

        public async Task<Data.Models.Comment> DeleteComment(string id)
        {
            var comment = await context.Comments.FindAsync(Guid.Parse(id));
            var userId = currentUserService.GetUserId();

            if (comment == null || comment.UserId!=userId || comment.IsDeleted==true)
            {
                return null;
            }

            context.Remove(comment);
            await context.SaveChangesAsync();
            return comment;

        }

        public async Task<IEnumerable<CommentModel>> GetCommentsFromResource(string resourceId)
        {
            if (resourceId.Length != 36)
            {
                return Enumerable.Empty<CommentModel>();
            }

            var userId = currentUserService.GetUserId();

            IEnumerable<CommentModel> comments = await context.Comments
                .OrderBy(c => c.CreatedOn)
                .Select(c => new CommentModel
                {
                    Id = c.Id.ToString(),
                    Content = c.Content,
                    CreatedAt = c.CreatedOn.ToString(Formatter.DateFormatter),
                    ResourceId = c.ResourceId.ToString(),
                    UserId = c.UserId,
                    UserName = c.User.UserName,
                    UserProfileImage = c.User.ProfilePictureUrl,
                    CommentLikes = c.CommentLikes,
                    HasLiked = c.CommentLikes.Select(cl => cl.UserId).Any(c => c == userId)
                }).Where(c => c.ResourceId == resourceId).ToArrayAsync();

            return comments;
        }

        private async Task<Resource?> GetResource(string resourceId)
        {
            var resource = await context.Resources.FirstOrDefaultAsync(r=>r.Id.ToString()==resourceId);
            return resource;
        }
    }
}