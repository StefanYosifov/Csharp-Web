using System.ComponentModel.DataAnnotations;
using _Project_CheatSheet.GlobalConstants.Comment;

namespace _Project_CheatSheet.Features.Comment.Models
{
    public class EditCommentModel
    {
        [StringLength(CommentConstants.ContentMaxLength, MinimumLength = CommentConstants.ContentMinLength)]
        public string Content { get; set; } = null!;
    }
}
