namespace _Project_CheatSheet.Features.Identity.Models
{
    using Common.GlobalConstants.User;
    using System.ComponentModel.DataAnnotations;

    public class LoginModel
    {
        [Required]
        [StringLength(UserConstants.NameMaxLength, MinimumLength = UserConstants.NameMinLength)]
        public string Username { get; set; } = null!;

        [Required]
        [StringLength(UserConstants.PasswordMaxLength, MinimumLength = UserConstants.PasswordMinLength)]
        public string Password { get; set; } = null!;
    }
}