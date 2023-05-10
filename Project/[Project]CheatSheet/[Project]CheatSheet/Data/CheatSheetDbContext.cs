using _Project_CheatSheet.Common.CurrentUser.Interfaces;
using _Project_CheatSheet.Data.Models;
using _Project_CheatSheet.Data.Models.Base;
using _Project_CheatSheet.Data.Models.Base.Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace _Project_CheatSheet.Data
{
    public partial class CheatSheetDbContext : IdentityDbContext<User>
    {

        private readonly IHttpContextAccessor httpContext;

        public CheatSheetDbContext()
        {
            
        }

        public CheatSheetDbContext(
            DbContextOptions<CheatSheetDbContext> options,
            IHttpContextAccessor httpContext)
            : base(options)
        {
            this.httpContext = httpContext;
        }

        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Resource> Resources { get; set; } = null!;
        public virtual DbSet<ResourceLike> ResourceLikes { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<CommentLike> CommentLikes { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<CategoryResource> CategoriesResources { get; set; } = null!;



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=CheatSheet;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ResourceLike>()
           .HasKey(r => new { r.UserId, r.ResourceId });

            modelBuilder.Entity<ResourceLike>()
                .HasOne(r => r.User)
                .WithMany(u => u.ResourceLikes)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ResourceLike>()
                .HasOne(r => r.Resource)
                .WithMany(p => p.ResourceLikes)
                .HasForeignKey(r => r.ResourceId)
                .OnDelete(DeleteBehavior.Restrict);

            // configure many-to-many relationship between User and Comment for CommentLikes
            modelBuilder.Entity<CommentLike>()
                .HasKey(c => new { c.UserId, c.CommentId });

            modelBuilder.Entity<CommentLike>()
                .HasOne(c => c.User)
                .WithMany(u => u.CommentLikes)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CommentLike>()
                .HasOne(c => c.Comment)
                .WithMany(c => c.CommentLikes)
                .HasForeignKey(c => c.CommentId)
                .OnDelete(DeleteBehavior.Restrict);

            // configure one-to-many relationship between User and Resource for Resources
            modelBuilder.Entity<Resource>()
                .HasOne(p => p.User)
                .WithMany(u => u.Resources)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            // configure one-to-many relationship between User and Comment for Comments
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict); // remove cascading delete behavior

            // configure one-to-many relationship between Resource and Comment for Comments
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Resource)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.ResourceId);

            modelBuilder.Entity<CategoryResource>()
                    .HasKey(k => new { k.CategoryId, k.ResourceId });

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            AuditSave();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            AuditSave();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }


        private void AuditSave()
        {
            var currentTime = DateTime.UtcNow;
            var userName = httpContext.HttpContext.User.Identity.Name;

            foreach (var item in ChangeTracker.Entries().Where(e => e.Entity is IEntity))
            {
                var entity = item.Entity as IEntity;

                if (item.State == EntityState.Added)
                {
                    entity.CreatedOn = currentTime;
                    entity.CreatedBy = userName;
                }
                else if (item.State == EntityState.Modified)
                {
                    entity.UpdatedOn = currentTime;
                    entity.UpdatedBy = userName;
                    item.Property("CreatedOn").IsModified = false;
                    item.Property("CreatedBy").IsModified = false;
                }
                else if (item.State == EntityState.Deleted && entity is IDeletableEntity deletableEntity)
                {
                    deletableEntity.IsDeleted = true;
                    deletableEntity.DeletedOn = currentTime;
                    deletableEntity.DeletedBy = userName;
                    item.State = EntityState.Modified;
                }
            }

        }
    }
}
