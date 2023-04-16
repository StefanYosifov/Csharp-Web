using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _Project_CheatSheet.Data.Models
{
    public class Resource
    {
        public Resource()
        {
            this.Categories = new HashSet<Category>();
            this.Likes = new HashSet<Like>();
            this.Comments = new HashSet<Comment>();

            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime CreateDate { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public virtual User User { get; set; } = null!;

        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
