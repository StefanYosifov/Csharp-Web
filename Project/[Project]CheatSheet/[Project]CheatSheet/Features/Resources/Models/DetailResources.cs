namespace _Project_CheatSheet.Features.Resources.Models
{
    using _Project_CheatSheet.Controllers.Resources;
    using _Project_CheatSheet.Data.Models;
    using _Project_CheatSheet.Features.Comment.Models;
    using System.ComponentModel.DataAnnotations;

    public class DetailResources
    {

        public DetailResources()
        {
            CategoryNames = new List<string>();
            this.CommentModels = new HashSet<CommentModel>();
            this.CommentLikes=new List<int>();
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
        public int Likes { get; set; }
        public string? UserId { get; set; }
        public string? UserName { get; set; }
        public string? UserImage { get; set; }

        public IEnumerable<CommentModel> CommentModels { get; set; }

        public List<int> CommentLikes { get; set; }
        public IEnumerable<string> CategoryNames { get; set; } = null!;

    }
}
