namespace CheatSheetProject.Models
{
    using CheatSheetProject.Data;
    using CheatSheetProject.Data.Models;
    using System.ComponentModel.DataAnnotations;

    public class ResourceModel
    {

        public string Id { get; set; } = null!;

        [StringLength(ModelConstants.ResourceTitleMaxLength,MinimumLength =ModelConstants.ResourceTitleMinLength)]
        public string Title { get; set; } = null!;

        [StringLength(ModelConstants.ResourceImageUrlMaxLength)]
        public string ImageUrl { get; set; } = null!;

        [StringLength(ModelConstants.ResourceContentMaxLength,MinimumLength =ModelConstants.ResourceTitleMinLength)]
        public string Content { get; set; } = null!;

        public int UserId { get; set; }

        public ICollection<CategoryResource> CategoryResources { get; set; } = null!;
    }
}
