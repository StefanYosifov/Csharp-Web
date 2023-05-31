namespace ForumApp.Data.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.Extensions.Options;
    using Models;
    using Seeder;

    internal class PostConfiguration:IEntityTypeConfiguration<Post>
    {
        private readonly PostSeeder postSeeder;
        public PostConfiguration()
        {
            this.postSeeder = new PostSeeder();
        }

        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasData(this.postSeeder.GeneratePosts().ToArray());
        }
    }
}
