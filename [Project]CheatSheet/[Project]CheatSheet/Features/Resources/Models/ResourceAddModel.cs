namespace _Project_CheatSheet.Controllers.Resources.Models
{
    using _Project_CheatSheet.Data.Models;
    using System.ComponentModel.DataAnnotations;

    public class ResourceAddModel
    {

        public ResourceAddModel()
        {
            this.CategoryResources = new List<CategoryResource>();
        }


        [Required]
        [StringLength(ResourceConstants.TitleMaxLength, MinimumLength = ResourceConstants.TitleMinLength)]
        public string Title { get; set; } = null!;

       
        public string ImageUrl { get; set; } = null!;

        [Required]
        [StringLength(ResourceConstants.ContentMaxLength, MinimumLength = ResourceConstants.ContentMinLength)]
        public string Content { get; set; } = null!;

        public ICollection<CategoryResource> CategoryResources { get; set; } = null!;
    }
}
