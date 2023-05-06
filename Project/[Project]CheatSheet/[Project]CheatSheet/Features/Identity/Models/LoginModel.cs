using _Project_CheatSheet.Controllers.Identity;

namespace _Project_CheatSheet.Features.Identity.Models
{
    using _Project_CheatSheet.Common.ModelConstants;
    using System.ComponentModel.DataAnnotations;

    public class LoginModel
    {
        [Required]
        [StringLength(ModelConstants.UserNameMaxLength, MinimumLength = ModelConstants.UserNameMinLength)]
        public string Username { get; set; } = null!;

        [Required]
        [StringLength(ModelConstants.UserPasswordMaxLength, MinimumLength = ModelConstants.UserPasswordMinLength)]
        public string Password { get; set; } = null!;


    }
}
