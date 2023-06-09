namespace Library.Models
{
    using System.ComponentModel.DataAnnotations;
    using static GlobalConstants.GlobalConstants.CategoryConstants;
    public class BookCategoryModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(CategoryNameMaxLength,MinimumLength = CategoryNameMinLength)]
        public string Name { get; set; } = null!;
    }
}
