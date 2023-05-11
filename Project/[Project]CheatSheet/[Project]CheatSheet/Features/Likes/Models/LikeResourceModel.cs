using System.ComponentModel.DataAnnotations;
using _Project_CheatSheet.GlobalConstants.Likes;

namespace _Project_CheatSheet.Features.Likes.Models
{
    public class LikeResourceModel
    {
        [Required] public string ResourceId { get; set; } = null!;

        public bool HasLiked { get; set; }

        [Range(LikeConstants.MinTotalLikes, LikeConstants.MaxTotalLikes)]
        public int TotalLikes { get; set; }
    }
}