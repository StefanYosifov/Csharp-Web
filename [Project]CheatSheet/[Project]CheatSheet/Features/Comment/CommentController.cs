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
        public async Task<StatusCodeResult> PostAComment(CommentModel comment)
        {
            return await service.createAComment(comment);
        }


    }
}
