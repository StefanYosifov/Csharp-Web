using System.ComponentModel.DataAnnotations;
using _Project_CheatSheet.GlobalConstants.Category;

namespace _Project_CheatSheet.Features.Category.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(CategoryConstants.NameMaxCategory, MinimumLength = CategoryConstants.NameMinCategory)]
        public string Name { get; set; } = null!;
    }
}