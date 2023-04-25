namespace CheatSheetProject.Data.Data
{
    using CheatSheetProject.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class CheatSheetProjectDbContext : DbContext
    {

        public CheatSheetProjectDbContext()
        {

        }

        public CheatSheetProjectDbContext(DbContextOptions options)
            : base(options) 
        {

        }

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<Resource> Resources { get; set; } = null!;

        public DbSet<User> Users { get; set; } = null!;

        public DbSet<CategoryResource> CategoriesResources { get; set; } = null!;



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryResource>().HasKey(e => new
            {
                e.CategoryId,
                e.ResourceId
            });


            base.OnModelCreating(modelBuilder);
        }

    }
}
