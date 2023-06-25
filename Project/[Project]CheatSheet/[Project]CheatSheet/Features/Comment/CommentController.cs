namespace _Project_CheatSheet.Features.Comment
{
    using Common.GlobalConstants.Comment;
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
            try
            {
                var postCommentResult = await service.CreateAComment(comment);
                return Ok(postCommentResult);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
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
            try
            {
                var commentResult = await service.EditComment(id, comment);
                return Ok(commentResult);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }

        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteComment(string id)
        {
            try
            {
                var deleteResult = await service.DeleteComment(id);
                return Ok(deleteResult);
            }
            catch (Exception e)
            {
                return Forbid(e.Message);
            }

        }
    }
}