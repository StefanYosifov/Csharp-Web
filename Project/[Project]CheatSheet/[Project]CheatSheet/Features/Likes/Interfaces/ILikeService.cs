namespace _Project_CheatSheet.Features.Likes.Interfaces
{
    using Microsoft.AspNetCore.Mvc;
    using Models;

    public interface ILikeService
    {
        public int GetCommentLikesCount(LikeCommentModel likeComment);

        public Task<StatusCodeResult> LikeAComment(LikeCommentModel likeComment);

        public Task<StatusCodeResult> RemoveLikeFromComment(LikeCommentModel likeComment);

        public int GetResourceLikesCount(string id);

        public Task<StatusCodeResult> LikeAResource(LikeResourceModelAdd likeResource);

        public Task<StatusCodeResult> RemoveLikeFromResource(LikeResourceModel likeResource);
        public Task<IEnumerable<LikeResourceModel>> ResourcesLikes();
    }
}