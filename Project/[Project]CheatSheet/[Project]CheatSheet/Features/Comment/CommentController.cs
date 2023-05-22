namespace _Project_CheatSheet.Features.Comment
{
    using GlobalConstants.Comment;
    using Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    [Route("/comment")]
    [Authorize]
    public class CommentController : ApiController
    {
        private readonly ICommentService service;

        public CommentController(ICommentService service)
        {
            this.service = service;
        }


        [HttpPost("send")]
        public async Task<IActionResult> PostAComment(InputCommentModel comment)
        {
            var postCommentResult = await service.CreateAComment(comment);
            if (postCommentResult == null)
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