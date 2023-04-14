using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace _Project_CheatSheet.Data.Models
{
    public class Resource
    {
        public Resource()
        {
            Categories = new HashSet<Category>();
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public string Content { get; set; } = null!;

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public virtual User User { get; set; } = null!;

        public virtual ICollection<Category> Categories { get; set; }
    }
}
