namespace _Project_CheatSheet.Controllers.Resources.Models
{
    using _Project_CheatSheet.Data.Models;
    using System.ComponentModel.DataAnnotations;

    public class ResourceModel
    {

        public ResourceModel()
        {
            CategoryNames = new List<string>();
            this.Comments = new HashSet<Comment>();
        }

        [Required]
        public string Id { get; set; } = null!;

        [Required]
        [StringLength(ResourceConstants.TitleMaxLength, MinimumLength = ResourceConstants.TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [StringLength(ResourceConstants.ContentMaxLength, MinimumLength = ResourceConstants.ContentMinLength)]
        public string Content { get; set; } = null!;

        public string DateTime { get; set; } = null!;
        public string? UserId { get; set; }
        public string? UserName { get; set; }
        public IEnumerable<string>? CategoryNames { get; set; }

        public IEnumerable<Comment> Comments { get; set; } 
    }
}
