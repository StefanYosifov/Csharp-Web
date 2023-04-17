using System;
using System.Collections.Generic;
using _Project_CheatSheet.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace _Project_CheatSheet.Data
{
    public partial class CheatSheetDbContext : IdentityDbContext<User>
    {
        public CheatSheetDbContext()
        {
        }

        public CheatSheetDbContext(DbContextOptions<CheatSheetDbContext> options)
            : base(options)
        {


        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Resource> Resources { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        public virtual DbSet<Like> Likes { get; set; } = null!;

        public virtual DbSet<Comment> Comments { get; set; } = null!;

        public virtual DbSet<CommentLike> CommentLikes { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=CheatSheet;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasMany(d => d.Resources)
                    .WithMany(p => p.Categories)
                    .UsingEntity<Dictionary<string, object>>(
                        "CategoriesResource",
                        l => l.HasOne<Resource>().WithMany().HasForeignKey("ResourceId"),
                        r => r.HasOne<Category>().WithMany().HasForeignKey("CategoryId"),
                        j =>
                        {
                            j.HasKey("CategoryId", "ResourceId");

                            j.ToTable("CategoriesResources");

                            j.HasIndex(new[] { "ResourceId" }, "IX_CategoriesResources_ResourceId");
                        });
            });

            modelBuilder.Entity<Like>()
        .HasOne(l => l.Resource)
        .WithMany(p => p.Likes)
        .HasForeignKey(l => l.ResourceId)
        .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Like>()
                .HasOne(l => l.Comment)
                .WithMany(c => c.Likes)
                .HasForeignKey(l => l.CommentId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CommentLike>()
                .HasOne(cl => cl.Comment)
                .WithMany(c => c.CommentLikes)
                .HasForeignKey(cl => cl.CommentId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Resources)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Likes)
                .WithOne(l => l.User)
                .HasForeignKey(l => l.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Comments)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Resource>()
                .HasOne(p => p.User)
                .WithMany(u => u.Resources)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Resource>()
                .HasMany(p => p.Comments)
                .WithOne(c => c.Resource)
                .HasForeignKey(c => c.ResourceId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Resource)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.ResourceId)
                .OnDelete(DeleteBehavior.NoAction);

            
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Resource)
                .WithMany(r => r.Comments)
                .HasForeignKey(c => c.ResourceId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Resource>()
                .HasMany(r => r.Comments)
                .WithOne(c => c.Resource)
                .HasForeignKey(c => c.ResourceId)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(modelBuilder);
        }

    }
}
