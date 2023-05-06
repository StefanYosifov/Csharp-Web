using _Project_CheatSheet.Controllers.Identity;

namespace _Project_CheatSheet.Features.Identity.Models
{
    using _Project_CheatSheet.Common.ModelConstants;
    using System.ComponentModel.DataAnnotations;

    public class RegisterModel
    {
        [Required]
        [StringLength(ModelConstants.UserNameMaxLength, MinimumLength = ModelConstants.UserNameMinLength)]
        public string UserName { get; set; } = null!;

        [Required]
        [StringLength(ModelConstants.UserEmailMaxLength, MinimumLength = ModelConstants.UserEmailMinLength)]
        [EmailAddress]

        public string Email { get; set; } = null!;

        [Required]
        [StringLength(ModelConstants.UserPasswordMaxLength, MinimumLength = ModelConstants.UserPasswordMinLength)]
        public string Password { get; set; } = null!;

    }
}
