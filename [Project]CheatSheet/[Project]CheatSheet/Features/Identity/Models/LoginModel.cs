using _Project_CheatSheet.Controllers.Identity;

namespace _Project_CheatSheet.Features.Identity.Models
{
    using System.ComponentModel.DataAnnotations;

    public class LoginModel
    {
        [Required]
        [StringLength(IdentityConstantsModels.UserNameMaxLength, MinimumLength = IdentityConstantsModels.UserNameMinLength)]
        public string Username { get; set; } = null!;

        [Required]
        [StringLength(IdentityConstantsModels.PasswordMaxLength, MinimumLength = IdentityConstantsModels.PasswordMinLength)]
        public string Password { get; set; } = null!;


    }
}
