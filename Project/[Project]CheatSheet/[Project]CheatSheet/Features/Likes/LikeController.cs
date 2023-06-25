namespace _Project_CheatSheet.Features.Likes
{
    using Common.GlobalConstants.Likes;
    using Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    [Authorize]
    [Route("/like")]
    public class LikeController : ApiController
    {
        private readonly ILikeService likeService;

        public LikeController(ILikeService likeService)
        {
            this.likeService = likeService;
        }

        [HttpGet("comment/{id}")]
        public int CommentLikesCount(LikeCommentModel likeComment)
        {
            return likeService.GetCommentLikesCount(likeComment);
        }

        [HttpPost("comment/like")]
        public async Task<ActionResult> LikeAComment(LikeCommentModel commentModel)
        {
            try
            {
                var likeCommentResult = await likeService.LikeAComment(commentModel);
                return Ok(likeCommentResult);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("comment/remove")]
        public async Task<ActionResult> RemoveLikeFromComment(LikeCommentModel commentModel)
        {
            try
            {
                var removedLikedCommentResult = await likeService.RemoveLikeFromComment(commentModel);
                return Ok(removedLikedCommentResult);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("resource/{id}")]
        public IActionResult GetResourceLikes(string id)
        {
            return Ok(likeService.GetResourceLikesCount(id));
        }

        [HttpPost("resource/like/{id}")]
        public async Task<ActionResult> LikeAResource(LikeResourceModelAdd likeResource)
        {
            try
            {
                var likeResourceResult = await likeService.LikeAResource(likeResource);
                return Ok(likeResourceResult);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("resource/remove/{id}")]
        public async Task<ActionResult> RemoveLikeResource(LikeResourceModel likeResource)
        {
            try
            {
                var likedResourceResult = await likeService.RemoveLikeFromResource(likeResource);
                return Ok(likedResourceResult);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpGet("resource/all")]
        public async Task<ActionResult<IEnumerable<LikeResourceModel>>> GetAllResourceLikes()
        {
            var likeResourceResults = await likeService.ResourcesLikes();
            return Ok(likeResourceResults);
        }
    }
}