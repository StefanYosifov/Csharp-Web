namespace _Project_CheatSheet.Controllers.Profile.Models
{
    using _Project_CheatSheet.Features.Profile;
    using System.ComponentModel.DataAnnotations;

    public class ProfileModel
    {
        [Range(ProfileConstants.minValue,int.MaxValue)]
        public int PostCount { get; set; }
        [Range(ProfileConstants.minValue, int.MaxValue)]
        public int ResourceLikes { get; set; }
        [Range(ProfileConstants.minValue, int.MaxValue)]
        public int CommentLikes { get; set; }

    }
}
