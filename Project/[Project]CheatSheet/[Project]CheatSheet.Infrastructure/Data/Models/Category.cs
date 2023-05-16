using System.ComponentModel.DataAnnotations;
using _Project_CheatSheet.GlobalConstants.Category;

namespace _Project_CheatSheet.Infrastructure.Data.Models
{
    public class Category
    {
        public Category()
        {
            this.CategoryResources = new HashSet<CategoryResource>();
        }

        [Key] public int Id { get; set; }

        [Required]
        [MaxLength(CategoryConstants.NameMaxCategory)]
        public string Name { get; set; } = null!;

        public virtual ICollection<CategoryResource> CategoryResources { get; set; }
    }
}