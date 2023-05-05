﻿namespace _Project_CheatSheet.Features.Likes
{
    using _Project_CheatSheet.Controllers;
    using _Project_CheatSheet.Features.Likes.Interfaces;
    using _Project_CheatSheet.Features.Likes.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    [Route("/like")]
    public class LikeController:ApiController
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
            
            var likeCommentResult = await likeService.LikeAComment(commentModel);
            if (likeCommentResult.StatusCode == 404)
            {
                return BadRequest(LikesConstants.onFailedLikedComments);
            }
            return Ok(likeCommentResult);
        }


        [HttpPost("comment/remove")]
        public async Task<ActionResult> RemoveLikeFromComment(LikeCommentModel commentModel)
        {
            var removedLikedCommentResult = await likeService.RemoveLikeFromComment(commentModel);
            if (removedLikedCommentResult.StatusCode == 404)
            {
                return BadRequest(LikesConstants.onFailedRemoveComment);
            }

            return Ok(removedLikedCommentResult);
        }


        [HttpGet("resource/{id}")]
        public async Task<ActionResult> GetResourceLikes(string id)
        {
            return Ok(likeService.GetResourceLikesCount(id));
        }


        [HttpPost("resource/like/{id}")]
        public async Task<ActionResult> LikeAResource(LikeResourceModelAdd likeResource)
        {
            var likeResourceResult=await likeService.LikeAResource(likeResource);
            if (likeResourceResult.StatusCode == 404)
            {
                return BadRequest(LikesConstants.onFailedLikedResource);
            }
            return Ok(likeResourceResult);
        }


        [HttpPost("resource/remove/{id}")]
        public async Task<ActionResult> RemoveLikeResource(LikeResourceModel likeResource)
        {
            var likedResourceResult=await likeService.RemoveLikeFromResource(likeResource);
            if (likedResourceResult.StatusCode == 404)
            {
                return BadRequest(LikesConstants.onFailedRemoveResource);
            }
            return Ok(likedResourceResult);
        }

        [HttpGet("resource/all")]
        public async Task<ActionResult<IEnumerable<LikeResourceModel>>> GetAllResourceLikes()
        {
            var likeResourceResults = await likeService.ResourcesLikes();
            return Ok(likeResourceResults);
        }
    }
}
