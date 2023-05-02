namespace _Project_CheatSheet.Features.Likes.Services
{
    using _Project_CheatSheet.Common.CurrentUser.Interfaces;
    using _Project_CheatSheet.Data;
    using _Project_CheatSheet.Data.Models;
    using _Project_CheatSheet.Features.Likes.Interfaces;
    using _Project_CheatSheet.Features.Likes.Models;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class LikeService : ILikeService
    {

        private readonly CheatSheetDbContext context;
        private readonly IMapper mapper;
        private readonly ICurrentUser currentUserService;

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
                .Where(c=>c.Id.ToString()==commentModel.CommentId)
                .Count();   
        }
        public async Task<StatusCodeResult> LikeAComment(LikeCommentModel likeComment)
        {
            
            var currentUser = await currentUserService.GetUser();
            if (context.CommentLikes.Any(u => u.UserId == currentUser.Id.ToString()))
            {
                return new StatusCodeResult(StatusCodes.Status404NotFound);
            }

            CommentLike commentLike = new CommentLike()
            {
                UserId=currentUser.Id.ToString(),
                CommentId=Guid.Parse(likeComment.CommentId),
                CreatedAt=DateTime.Now
            };

            await context.CommentLikes.AddAsync(commentLike);
            await context.SaveChangesAsync();
            return new StatusCodeResult(StatusCodes.Status200OK);
        }
        public async Task<StatusCodeResult> RemoveLikeFromComment(LikeCommentModel likeComment)
        {
            var currentUser = await currentUserService.GetUser();
            var commentLike = await context.CommentLikes.FirstOrDefaultAsync(c=>c.CommentId.ToString()==likeComment.CommentId);
            if(commentLike == null || currentUser.Id!=commentLike.UserId)
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
                .Where(rl => rl.ResourceId.ToString() == id)
                .Count();
        }
        public async Task<StatusCodeResult> LikeAResult(LikeResourceModel likeResource)
        {
            var currentUser = await currentUserService.GetUser();
            if (context.ResourceLikes.Any(rl => rl.UserId == currentUser.Id.ToString()))
            {
                return new StatusCodeResult(StatusCodes.Status404NotFound);
            }

            var likeResult=mapper.Map<ResourceLike>(likeResource);
            likeResult.UserId=currentUser.Id;
            likeResult.CreatedAt = DateTime.Now;

            await context.ResourceLikes.AddAsync(likeResult);
            await context.SaveChangesAsync();
            return new StatusCodeResult(StatusCodes.Status201Created);
        }
        public async Task<StatusCodeResult> RemoveLikeFromResource(LikeResourceModel likeResource)
        {
            var currentUser = await currentUserService.GetUser();
            var resourceLike=await context.ResourceLikes.FirstOrDefaultAsync(rl => rl.Id.ToString() == likeResource.ResourceId);
            if(resourceLike==null || resourceLike.UserId != currentUser.Id)
            {
                return new StatusCodeResult(StatusCodes.Status404NotFound);
            }
            context.Remove(resourceLike);
            await context.SaveChangesAsync();
            return new StatusCodeResult(StatusCodes.Status200OK);
        }
        public async Task<StatusCodeResult> CheckIfResourceIsLikedByUser(string resourceId)
        {
            var currentUser = await currentUserService.GetUser();
            var resourceLikeResult = await context.ResourceLikes.FirstOrDefaultAsync(rl => rl.Id.ToString() == resourceId);
            if (resourceLikeResult == null)
            {
                return new StatusCodeResult(StatusCodes.Status404NotFound);
            }
            return new StatusCodeResult(StatusCodes.Status200OK);
        }
        public async Task<IEnumerable<LikeResourceModel>> ResourcesLikes()
        {
            var currentUser = await currentUserService.GetUser();
            var resourceLikes = await context.ResourceLikes
                .Include(rl => rl.User)
                .Select(rl => new LikeResourceModel()
                {
                    ResourceId = rl.ResourceId.ToString(),
                    hasLiked = rl.Resource.ResourceLikes.Any(u => u.UserId == currentUser.Id),
                    TotaLikes = context.ResourceLikes.Count(x=>x.ResourceId==rl.ResourceId),
                }).Distinct().ToArrayAsync();
            return resourceLikes;
        }
    }
}
