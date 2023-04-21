using System;
using System.Collections.Generic;

namespace _Project_CheatSheet.Data.Models
{
    public class Category
    {
        public Category()
        {
            CategoryResources = new HashSet<CategoryResource>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<CategoryResource> CategoryResources { get; set; }
    }
}
