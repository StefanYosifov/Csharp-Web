namespace _Project_CheatSheet.Features.Likes
{
    using _Project_CheatSheet.Controllers;
    using _Project_CheatSheet.Features.Likes.Interfaces;
    using _Project_CheatSheet.Features.Likes.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class LikeController:ApiController
    {

        private readonly ILikeService likeService;

        public LikeController(ILikeService likeService)
        {
            this.likeService = likeService;
        }

        [Authorize]
        [HttpGet]
        [Route("/like/comment/{id}")]
        public int CommentLikesCount(LikeCommentModel likeComment)
        {
            return likeService.getCommentLikeCount(likeComment);
        }


        [Authorize]
        [HttpPost]
        [Route("/like/comment/like")]
        public async Task<ActionResult> LikeAComment(LikeCommentModel commentModel)
        {
            
            var likeCommentResult = await likeService.LikeAComment(commentModel);
            if (likeCommentResult.StatusCode == 404)
            {
                return BadRequest(LikesConstants.onFailedLikedComments);
            }
            return Ok(likeCommentResult);
        }

        [Authorize]
        [HttpPost]
        [Route("/like/comment/remove")]
        public async Task<ActionResult> RemoveLikeFromComment(LikeCommentModel commentModel)
        {
            var removedLikedCommentResult = await likeService.RemoveLikeFromComment(commentModel);
            if (removedLikedCommentResult.StatusCode == 404)
            {
                return BadRequest(LikesConstants.onFailedRemoveComment);
            }

            return Ok(removedLikedCommentResult);
        }

        [Authorize]
        [HttpPost]
        [Route("/like/resource/like")]
        public async Task<ActionResult> LikeAResource(LikeResourceModel likeResource)
        {
            var likeResourceResult=await likeService.LikeAResult(likeResource);
            if (likeResourceResult.StatusCode == 404)
            {
                return BadRequest(LikesConstants.onFailedLikedResource);
            }
            return Ok(likeResourceResult);
        }

        [Authorize]
        [HttpPost]
        [Route("/like/resource/remove")]
        public async Task<ActionResult> RemoveLikeResource(LikeResourceModel likeResource)
        {
            var likedResourceResult=await likeService.RemoveLikeFromResource(likeResource);
            if (likedResourceResult.StatusCode == 404)
            {
                return BadRequest(LikesConstants.onFailedRemoveResource);
            }
            return Ok(likedResourceResult);
        }
    }
}
