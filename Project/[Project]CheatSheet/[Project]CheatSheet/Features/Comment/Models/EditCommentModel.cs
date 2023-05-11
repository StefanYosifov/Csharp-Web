using System.ComponentModel.DataAnnotations;
using _Project_CheatSheet.GlobalConstants.Comment;

namespace _Project_CheatSheet.Features.Comment.Models
{
    public class EditCommentModel
    {
        [StringLength(CommentConstants.ContentMinLength, MinimumLength = CommentConstants.ContentMaxLength)]
        public string Content { get; set; } = null!;
    }
}
