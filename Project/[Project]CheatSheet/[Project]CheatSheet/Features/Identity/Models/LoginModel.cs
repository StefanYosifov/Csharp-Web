using System.ComponentModel.DataAnnotations;
using _Project_CheatSheet.GlobalConstants.User;

namespace _Project_CheatSheet.Features.Identity.Models
{
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