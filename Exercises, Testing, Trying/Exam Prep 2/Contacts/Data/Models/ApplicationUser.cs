namespace Contacts.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using static GlobalConstants.GlobalConstants.ApplicationUserConstants;
    public class ApplicationUser:IdentityUser
    {

        public ApplicationUser()
        {
            this.ApplicationUserContacts = new HashSet<ApplicationUserContact>();
        }

        [Required]
        [MaxLength(UserNameMaxLength)]
        public override string UserName { get => base.UserName; set => base.UserName = value; }

        [Required]
        [MaxLength(EmailMaxLength)]
        public override string Email { get => base.Email; set => base.Email = value; }

        public ICollection<ApplicationUserContact> ApplicationUserContacts { get; set; }
    }
}
