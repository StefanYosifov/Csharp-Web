namespace _Project_CheatSheet.Features.Comment.Interfaces
{
    using _Project_CheatSheet.Features.Comment.Models;
    using Microsoft.AspNetCore.Mvc;

    public interface ICommentService
    {

        public Task<IEnumerable<CommentModel>> getCommentsFromResource(string resourceId);

        public Task<StatusCodeResult> createAComment(CommentModel comment);

    }
}
