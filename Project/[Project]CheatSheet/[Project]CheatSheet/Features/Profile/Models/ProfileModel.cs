namespace _Project_CheatSheet.Controllers.Profile.Models
{
    using _Project_CheatSheet.Features.Profile;
    using _Project_CheatSheet.Features.Profile.Models;
    using _Project_CheatSheet.GlobalConstants.Profile;
    using System.ComponentModel.DataAnnotations;

    public class ProfileModel
    {
        [Range(ProfileConstants.minValue, ProfileConstants.maxValue)]
        public int PostCount { get; set; }
        [Range(ProfileConstants.minValue, ProfileConstants.maxValue)]
        public int ResourceLikes { get; set; }
        [Range(ProfileConstants.minValue, ProfileConstants.maxValue)]
        public int CommentLikes { get; set; }
        [Required]
        public virtual UserModel User { get; set; } = null!;
    }
}
