namespace ForumApp.Services.Interfaces
{
    using Models;

    public interface IPostService
    {

        Task<IEnumerable<PostViewModel>> getAllPostsAsync();

        Task AddPostAsync(PostInputViewModel postModel);

        Task<PostOutputViewModel> GetPostByIdAsync(int id);

        Task EditByIdAsync(int id, PostInputViewModel editModel);

        Task DeleteByIdAsync(int id);
    }
}
