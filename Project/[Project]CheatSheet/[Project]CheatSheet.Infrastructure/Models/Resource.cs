using System;
using System.Collections.Generic;

namespace _Project_CheatSheet.Infrastructure.Models
{
    public partial class Resource
    {
        public Resource()
        {
            Categories = new HashSet<Category>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public string Content { get; set; } = null!;
        public int UserId { get; set; }

        public virtual User User { get; set; } = null!;

        public virtual ICollection<Category> Categories { get; set; }
    }
}
