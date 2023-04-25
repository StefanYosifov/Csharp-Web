namespace _Project_CheatSheet.Features.Comment.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CommentModel
    {

        public CommentModel()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; } = null!;

        public string? UserName { get; set; } = null!;


        [StringLength(ModelConstants.ResourceContentMaxLength, MinimumLength = ModelConstants.ResourceContentMinLength)]

        public string Content { get; set; }= null!;
        public string? UserProfileImage { get; set; }
        public string? CreatedAt { get; set; } = null!;

        public string? ResourceId { get; set; }

    }
}
