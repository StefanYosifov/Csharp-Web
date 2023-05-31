namespace ForumApp.Data.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Post
    {
        [Key]
        public int Id { get; init; }

        [Required]
        [MaxLength(ValidationConstants.TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(ValidationConstants.ContentMaxLength)]
        public string Content { get; set; } = null!;

    }
}
