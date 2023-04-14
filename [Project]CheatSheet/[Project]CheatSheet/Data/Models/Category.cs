using System;
using System.Collections.Generic;

namespace _Project_CheatSheet.Data.Models
{
    public class Category
    {
        public Category()
        {
            Resources = new HashSet<Resource>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Resource> Resources { get; set; }
    }
}
