namespace _Project_CheatSheet.Controllers.Resources.Models
{
    using _Project_CheatSheet.GlobalConstants.Resource;
    using System.ComponentModel.DataAnnotations;

    public class ResourceAddModel
    {

        public ResourceAddModel()
        {
            this.CategoryIds = new List<int>();
        }

        [Required]
        [StringLength(ResourceConstants.TitleMaxLength, MinimumLength = ResourceConstants.TitleMinLength)]
        public string Title { get; set; } = null!;

        [StringLength(ResourceConstants.ImageUrlMaxLength, MinimumLength = ResourceConstants.ImageUrlMinLength)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [StringLength(ResourceConstants.ContentMaxLength, MinimumLength = ResourceConstants.ContentMinLength)]
        public string Content { get; set; } = null!;
        public ICollection<int> CategoryIds { get; set; } = null!;
    }
}
