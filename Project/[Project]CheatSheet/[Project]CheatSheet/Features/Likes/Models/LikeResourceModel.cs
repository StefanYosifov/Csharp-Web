namespace _Project_CheatSheet.Features.Likes.Models
{
    using _Project_CheatSheet.GlobalConstants.Likes;
    using System.ComponentModel.DataAnnotations;

    public class LikeResourceModel
    {
        [Required]
        public string ResourceId { get; set; } = null!;

        public bool hasLiked { get; set; }

        [Range(LikeConstants.minTotalLikes,LikeConstants.maxTotalLikes)]
        public int TotaLikes { get; set; }

    }
}
