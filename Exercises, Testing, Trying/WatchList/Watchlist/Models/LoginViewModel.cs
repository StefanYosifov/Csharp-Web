namespace Watchlist.Models
{
    using System.ComponentModel.DataAnnotations;

    public class LoginViewModel
    {
        [Required]
        [StringLength(GlobalConstants.UserNameMax,MinimumLength = GlobalConstants.UserNameMin)]
        public string UserName { get; set; }

        [Required]
        [StringLength(GlobalConstants.UserPasswordMax,MinimumLength = GlobalConstants.UserNameMin)]
        public string Password { get; set; }
    }
}
