namespace _Project_CheatSheet.Controllers.Identity
{
    using System.ComponentModel.DataAnnotations;

    public class LoginModel
    {
        [Required]
        [StringLength(IdentityConstants.UserNameMaxLength,MinimumLength =IdentityConstants.UserNameMinLength)]
        public string Username { get; set; } = null!;

        [Required]
        [StringLength (IdentityConstants.PasswordMaxLength, MinimumLength = IdentityConstants.PasswordMinLength)]
        public string Password { get; set; } = null!;


    }
}
