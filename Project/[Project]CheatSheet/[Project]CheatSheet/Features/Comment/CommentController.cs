namespace _Project_CheatSheet.Features.Comment
{
    using _Project_CheatSheet.Controllers;
    using _Project_CheatSheet.Features.Comment.Interfaces;
    using _Project_CheatSheet.Features.Comment.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class CommentController:ApiController
    {

        private readonly ICommentService service;
        public CommentController(ICommentService service)
        {
            this.service = service;
        }


        [Authorize]
        [HttpPost]
        [Route("/comment/send")]
        public async Task<ActionResult> PostAComment(CommentModel comment)
        {
            var postComment = await service.createAComment(comment);
            if (postComment.StatusCode != 201)
            {
                return BadRequest("Couldn't create a comment");
            }
            return Ok("You have sucessfully created a comment");
        }

        [Authorize]
        [HttpGet]
        [Route("/comment/get/{id}")]
        public async Task<ActionResult<IEnumerable<CommentModel>>> GetComments(string id)
        {
            var comments = await service.getCommentsFromResource(id);
            if (comments == null || comments.Count() == 0)
            {
                return NotFound(comments);
            }
            return Ok(comments);
        }


    }
}
