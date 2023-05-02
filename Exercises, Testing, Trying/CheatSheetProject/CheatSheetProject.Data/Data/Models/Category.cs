namespace CheatSheetProject.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Category
    {
        public Category()
        {
            this.CategoryResources = new HashSet<CategoryResource>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public ICollection<CategoryResource> CategoryResources{ get; set; }

    }
}
