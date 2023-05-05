namespace _Project_CheatSheet.Controllers.Category.Models
{
    using _Project_CheatSheet.Common.ModelConstants;
    using System.ComponentModel.DataAnnotations;

    public class CategoryModel
    {
        
        public int Id { get; set; }
        [Required]
        [StringLength(ModelConstants.CategoryNameMaxCategory,MinimumLength = ModelConstants.CategoryNameMinCategory)]
        public string Name { get; set; } = null!;

    }
}
