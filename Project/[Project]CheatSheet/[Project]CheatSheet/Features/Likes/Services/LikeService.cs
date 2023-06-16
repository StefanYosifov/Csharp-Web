namespace _Project_CheatSheet.Features.Likes.Services
{
    using AutoMapper;
    using Common.UserService.Interfaces;
    using Infrastructure.Data;
    using Infrastructure.Data.Models;
    using Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class LikeService : ILikeService
    {
        private readonly CheatSheetDbContext context;
        private readonly ICurrentUser currentUserService;
        private readonly IMapper mapper;

        public LikeService(
            CheatSheetDbContext context,
            ICurrentUser currentUserService,
            IMapper mapper)
        {
            this.context = context;
            this.currentUserService = currentUserService;
            this.mapper = mapper;
        }

        public int GetCommentLikesCount(LikeCommentModel commentModel)
        {
            return context.CommentLikes
                .Count(c => c.Id.ToString() == commentModel.CommentId);
        }

        public async Task<StatusCodeResult> LikeAComment(LikeCommentModel likeComment)
        {
            var currentUser = await currentUserService.GetUser();
            var findComment = await context.Comments.FindAsync(Guid.Parse(likeComment.CommentId));
            if (findComment == null || findComment.CommentLikes.Any(cl => cl.UserId == currentUser.Id))
            {
                return new StatusCodeResult(StatusCodes.Status404NotFound);
            }

            var commentLike = new CommentLike
            {
                UserId = currentUser.Id,
                CommentId = Guid.Parse(likeComment.CommentId),
                CreatedOn = DateTime.Now
            };

            await context.CommentLikes.AddAsync(commentLike);
            await context.SaveChangesAsync();
            return new StatusCodeResult(StatusCodes.Status200OK);
        }

        public async Task<StatusCodeResult> RemoveLikeFromComment(LikeCommentModel likeComment)
        {
            var currentUser = await currentUserService.GetUser();
            var commentLike =
                await context.CommentLikes.FirstOrDefaultAsync(c => c.CommentId.ToString() == likeComment.CommentId);
            if (commentLike == null || currentUser.Id != commentLike.UserId)
            {
                return new StatusCodeResult(StatusCodes.Status404NotFound);
            }

            context.Remove(commentLike);
            await context.SaveChangesAsync();
            return new StatusCodeResult(StatusCodes.Status200OK);
        }

        public int GetResourceLikesCount(string id)
        {
            return context.ResourceLikes
                .Count(rl => rl.ResourceId.ToString() == id);
        }

        public async Task<StatusCodeResult> LikeAResource(LikeResourceModelAdd likeResource)
        {
            var currentUser = await currentUserService.GetUser();
            if (context.ResourceLikes.Any(rl => rl.UserId == currentUser.Id
                                                && rl.ResourceId.ToString() == likeResource.ResourceId))
            {
                return new StatusCodeResult(StatusCodes.Status404NotFound);
            }

            var likeResult = mapper.Map<ResourceLike>(likeResource);
            likeResult.UserId = currentUser.Id;
            likeResult.CreatedAt = DateTime.Now;

            await context.ResourceLikes.AddAsync(likeResult);
            await context.SaveChangesAsync();
            return new StatusCodeResult(StatusCodes.Status201Created);
        }

        public async Task<StatusCodeResult> RemoveLikeFromResource(LikeResourceModel likeResource)
        {
            var currentUser = await currentUserService.GetUser();
            var resourceLike =
                await context.ResourceLikes.FirstOrDefaultAsync(rl =>
                    rl.ResourceId.ToString() == likeResource.ResourceId);
            if (resourceLike == null || resourceLike.UserId != currentUser.Id)
            {
                return new StatusCodeResult(StatusCodes.Status404NotFound);
            }

            context.Remove(resourceLike);
            await context.SaveChangesAsync();
            return new StatusCodeResult(StatusCodes.Status200OK);
        }

        public async Task<IEnumerable<LikeResourceModel>> ResourcesLikes()
        {
            var currentUser = await currentUserService.GetUser();
            var resourceLikes = await context.ResourceLikes
                .Include(rl => rl.User)
                .Select(rl => new LikeResourceModel
                {
                    ResourceId = rl.ResourceId.ToString(),
                    HasLiked = rl.Resource.ResourceLikes.Any(u => u.UserId == currentUser.Id),
                    TotalLikes = context.ResourceLikes.Count(x => x.ResourceId == rl.ResourceId)
                })
                .Distinct()
                .ToArrayAsync();
            return resourceLikes;
        }
    }
}