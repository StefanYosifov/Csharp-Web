using _Project_CheatSheet.Controllers.Identity;

namespace _Project_CheatSheet.Features.Identity.Models
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterModel
    {
        [Required]
        [StringLength(IdentityConstantsModels.UserNameMaxLength, MinimumLength = IdentityConstantsModels.UserNameMinLength)]
        public string UserName { get; set; } = null!;

        [Required]
        [StringLength(IdentityConstantsModels.EmailMaxLength, MinimumLength = IdentityConstantsModels.EmailMinLength)]
        [EmailAddress]

        public string Email { get; set; } = null!;

        [Required]
        [StringLength(IdentityConstantsModels.PasswordMaxLength, MinimumLength = IdentityConstantsModels.PasswordMinLength)]
        public string Password { get; set; } = null!;

    }
}
