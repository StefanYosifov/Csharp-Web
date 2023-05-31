namespace ForumApp.Services
{
    using Data.Data;
    using Data.Data.Models;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class PostService:IPostService
    {
        private readonly ApplicationDbContext context;

        public PostService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<PostViewModel>> getAllPostsAsync()
        {
            return await context.Posts.Select(p=>new PostViewModel()
            {
                Id = p.Id,
                Content = p.Content,
                Title = p.Title
            }).ToArrayAsync();

        }

        public async Task AddPostAsync(PostInputViewModel postModel)
        {
           Post post=new Post()
           {
               Title = postModel.Title,
               Content = postModel.Content,
           };

           await context.AddAsync(post);
           await context.SaveChangesAsync();
           
        }

        public async Task EditByIdAsync(int id, PostInputViewModel editModel)
        {
            var postToEdit = await context.Posts.FirstOrDefaultAsync(p => p.Id == id);

            postToEdit.Title=editModel.Title;
            postToEdit.Content=editModel.Content;

            await context.SaveChangesAsync();
        }
    }
}
