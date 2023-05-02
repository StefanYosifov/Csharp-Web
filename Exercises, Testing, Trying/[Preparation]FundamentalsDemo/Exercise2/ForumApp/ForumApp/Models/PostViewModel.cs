namespace ForumApp.Models
{
    using ForumApp.Common;
    using System.ComponentModel.DataAnnotations;

    public class PostViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(GlobalConstants.PostTitleMaxLength,MinimumLength=GlobalConstants.PostTitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(GlobalConstants.PostContentMaxLength, MinimumLength = GlobalConstants.PostContentMinLength)]
        public string Content { get; set; } = null!;

    }
}
