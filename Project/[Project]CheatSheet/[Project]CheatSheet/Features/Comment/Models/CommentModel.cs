namespace _Project_CheatSheet.Features.Comment.Models
{
    using _Project_CheatSheet.Data.Models;
    using _Project_CheatSheet.GlobalConstants.Comment;

    using System.ComponentModel.DataAnnotations;

    public class CommentModel
    {

        public CommentModel()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CommentLikes = new HashSet<CommentLike>();
        }

        [Required]
        public string Id { get; set; } = null!;
        public string? UserName { get; set; } = null!;

        [StringLength(CommentConstants.ContentMinLength, MinimumLength = CommentConstants.ContentMaxLength)]
        public string Content { get; set; }= null!;
        public string? UserProfileImage { get; set; }
        public string? CreatedAt { get; set; } = null!;
        public string? ResourceId { get; set; }
        public bool HasLiked { get; set; }
        public ICollection<CommentLike> CommentLikes { get; set; }
    }
}
