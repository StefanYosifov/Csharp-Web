using _Project_CheatSheet.Features.Comment.Models;
using Microsoft.AspNetCore.Mvc;

namespace _Project_CheatSheet.Features.Comment.Interfaces
{
    public interface ICommentService
    {
        public Task<IEnumerable<CommentModel>> GetCommentsFromResource(string resourceId);

        public Task<StatusCodeResult> CreateAComment(CommentModel comment);

        public Task<EditCommentModel> EditComment(string id,EditCommentModel commentModel);
    }
}