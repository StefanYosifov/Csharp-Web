namespace _Project_CheatSheet.Features.Profile.Models
{
    using System.ComponentModel.DataAnnotations;

    public class UserModel
    {
        [Required]
        public string UserName { get; set; } = null!;

        [Required]
        public string UserId { get; set; } = null!;

        public string? UserDescription { get; set; }

        public string? UserProfilePicture { get; set; }
    }
}
