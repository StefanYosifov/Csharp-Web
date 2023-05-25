namespace Watchlist.Models
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterViewModel
    {

        [Required]
        [StringLength(GlobalConstants.UserNameMax, MinimumLength = GlobalConstants.UserNameMin)]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(GlobalConstants.UserEmailMax,MinimumLength = GlobalConstants.UserEmailMin)]
        public string Email { get; set; }

        [Required]
        [StringLength(GlobalConstants.UserPasswordMax, MinimumLength = GlobalConstants.UserNameMin)]
        public string Password { get; set; }

        [Required]
        [StringLength(GlobalConstants.UserPasswordMax, MinimumLength = GlobalConstants.UserNameMin)]

        public string ConfirmPassword { get; set; }

    }
}
