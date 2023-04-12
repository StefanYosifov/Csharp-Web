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

        public DbSet<Category> Categories { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<CategoryResource> CategoriesResources { get; set; }



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
