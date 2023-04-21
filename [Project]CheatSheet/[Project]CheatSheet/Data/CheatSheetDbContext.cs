﻿using System;
using System.Collections.Generic;
using _Project_CheatSheet.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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

    }
}
