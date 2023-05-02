namespace ForumApp.Data.Models
{
    using ForumApp.Common;
    using System.ComponentModel.DataAnnotations;

    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.PostTitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(GlobalConstants.PostContentMaxLength)]

        public string Content { get; set; }=null!;

    }
}
