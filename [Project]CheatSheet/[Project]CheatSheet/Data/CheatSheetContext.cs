using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace _Project_CheatSheet.Data
{
    public partial class CheatSheetContext : DbContext
    {
        public CheatSheetContext()
        {
        }

        public CheatSheetContext(DbContextOptions<CheatSheetContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Resource> Resources { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

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

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_Resources_UserId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Content).HasMaxLength(3000);

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Resources)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(30);

                entity.Property(e => e.Name).HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
