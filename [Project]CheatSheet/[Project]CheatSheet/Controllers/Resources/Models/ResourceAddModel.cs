namespace _Project_CheatSheet.Controllers.Resources.Models
{
    using _Project_CheatSheet.Data.Models;
    using System.ComponentModel.DataAnnotations;

    public class ResourceAddModel
    {

        public ResourceAddModel()
        {
            this.Categories = new List<Category>();
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

        public string? UserId { get; set; }
        public ICollection<Category> Categories { get; set; } = null!;
    }
}
