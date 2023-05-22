namespace _Project_CheatSheet.Features.Comment.Interfaces
{
    using Infrastructure.Data.Models;
    using Models;

    public interface ICommentService
    {
        public Task<IEnumerable<CommentModel>> GetCommentsFromResource(string resourceId);

        public Task<InputCommentModel> CreateAComment(InputCommentModel comment);

        public Task<EditCommentModel> EditComment(string id, EditCommentModel commentModel);

        public Task<Comment> DeleteComment(string id); //Todo Investigate why using isn't working
    }
}