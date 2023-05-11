using System.ComponentModel.DataAnnotations;

namespace _Project_CheatSheet.Features.Likes.Models
{
    public class LikeCommentModel
    {
        [Required] public string CommentId { get; set; } = null!;
    }
}