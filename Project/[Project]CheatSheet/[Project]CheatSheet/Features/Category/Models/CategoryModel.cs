namespace _Project_CheatSheet.Features.Category.Models
{
    using Common.GlobalConstants.Category;
    using System.ComponentModel.DataAnnotations;

    public class CategoryModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(CategoryConstants.NameMaxCategory, MinimumLength = CategoryConstants.NameMinCategory)]
        public string Name { get; set; } = null!;
    }
}