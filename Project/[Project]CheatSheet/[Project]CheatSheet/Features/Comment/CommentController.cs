using _Project_CheatSheet.Features.Comment.Interfaces;
using _Project_CheatSheet.Features.Comment.Models;
using _Project_CheatSheet.GlobalConstants.Comment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _Project_CheatSheet.Features.Comment
{
    [Route("comment")]
    [Authorize]
    public class CommentController : ApiController
    {
        private readonly ICommentService service;

        public CommentController(ICommentService service)
        {
            this.service = service;
        }


        [HttpPost("send")]
        public async Task<IActionResult> PostAComment(CommentModel comment)
        {
            var postCommentResult = await service.CreateAComment(comment);
            if (postCommentResult.StatusCode != 201)
            {
                return BadRequest(CommentMessages.OnUnsuccessfulPostComment);
            }

            return Ok(CommentMessages.OnSuccessfulPostComment);
        }

        [HttpGet("get/{id}")]
        public async Task<ActionResult<IEnumerable<CommentModel>>> GetComments(string id)
        {
            var commentsResult = await service.GetCommentsFromResource(id);
            return Ok(commentsResult);
        }

        [HttpPatch("edit/{id}")]
        public async Task<IActionResult> EditComment(string id, EditCommentModel comment)
        {
            var commentResult = await service.EditComment(id, comment);
            if (commentResult == null)
            {
                return NotFound(CommentMessages.OnUnsuccessfulEditComment);
            }

            return Ok(CommentMessages.OnSuccessfulEditComment);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteComment(string id)
        {
            var deleteResult = await service.DeleteComment(id);
            if (deleteResult == null)
            {
                return Forbid();
            }
            return Ok(deleteResult);    
        }
    }
}