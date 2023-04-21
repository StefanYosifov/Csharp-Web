using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _Project_CheatSheet.Data.Models
{
    public class Resource:BaseEntity
    {
        public Resource()
        {
            this.CategoryResources = new HashSet<CategoryResource>();
            this.ResourceLikes = new HashSet<ResourceLike>();
            this.Comments = new HashSet<Comment>();
            this.Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public string Content { get; set; } = null!;

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public virtual User User { get; set; } = null!;

        public virtual ICollection<CategoryResource> CategoryResources { get; set; }
        public ICollection<ResourceLike> ResourceLikes { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
