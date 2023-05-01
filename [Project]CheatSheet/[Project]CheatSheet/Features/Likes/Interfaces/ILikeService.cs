namespace _Project_CheatSheet.Features.Likes.Interfaces
{
    using _Project_CheatSheet.Features.Likes.Models;
    using Microsoft.AspNetCore.Mvc;

    public interface ILikeService
    {

        public int GetCommentLikesCount(LikeCommentModel likeComment);

        public Task<StatusCodeResult> LikeAComment(LikeCommentModel likeComment);

        public Task<StatusCodeResult> RemoveLikeFromComment(LikeCommentModel likeComment);

        public int GetResourceLikesCount(string id);

        public Task<StatusCodeResult> LikeAResult(LikeResourceModel likeResource);

        public Task<StatusCodeResult> RemoveLikeFromResource(LikeResourceModel likeResource);
        public Task<IEnumerable<LikeResourceModel>> ResourcesLikes();
    }
}
