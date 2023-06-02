namespace ForumApp.Models
{
    using System.ComponentModel.DataAnnotations;
    using Data.Data;

    public class PostOutputViewModel
    {
        [Required]
        [StringLength(ValidationConstants.TitleMaxLength, MinimumLength = ValidationConstants.TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(ValidationConstants.ContentMaxLength, MinimumLength = ValidationConstants.ContentMinLength)]
        public string Content { get; set; } = null!;
    }
}