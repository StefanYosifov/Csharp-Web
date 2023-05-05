namespace _Project_CheatSheet.Controllers.Resources.Models
{
    using _Project_CheatSheet.Common.ModelConstants;
    using _Project_CheatSheet.Data.Models;
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

        [StringLength(ModelConstants.ResourceContentMaxLength, MinimumLength = ModelConstants.ResourceImageUrlMinLength)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [StringLength(ResourceConstants.ContentMaxLength, MinimumLength = ResourceConstants.ContentMinLength)]
        public string Content { get; set; } = null!;

        public ICollection<int> CategoryIds { get; set; } = null!;
    }
}
