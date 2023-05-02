namespace ForumApp.Data.Seed
{
    using ForumApp.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            List<Post> posts = GetPosts();

            builder.HasData(posts);
        }


        private List<Post> GetPosts()
        {
            return new List<Post>()
            {
                new Post()
                {
                    Id=1,
                    Title="My First Post",
                    Content="Crud operations in MVC"
                },
                new Post()
                {
                    Id=2,
                    Title="My Second Post",
                    Content="Crud operations in MVC are getting even more fun"
                },
                new Post()
                {
                    Id=3,
                    Title="My Third Post",
                    Content="Hello there, I am getting better at Crud operations with MVC"
                },
            };
        }
    }
}
