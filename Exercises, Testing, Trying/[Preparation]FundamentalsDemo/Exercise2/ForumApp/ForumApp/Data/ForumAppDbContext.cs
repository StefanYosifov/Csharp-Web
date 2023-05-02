namespace ForumApp.Data
{
    using ForumApp.Data.Models;
    using ForumApp.Data.Seed;
    using Microsoft.EntityFrameworkCore;

    public class ForumAppDbContext : DbContext
    {
        public ForumAppDbContext(DbContextOptions<ForumAppDbContext> options)
            :base(options)
        {
            this.Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration<Post>(new PostConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Post> Posts { get; init; } = null!;


    }
}
