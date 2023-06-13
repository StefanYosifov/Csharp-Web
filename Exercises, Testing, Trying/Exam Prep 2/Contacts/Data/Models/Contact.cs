namespace Contacts.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static GlobalConstants.GlobalConstants.ContactConstants;

    public class Contact
    {
        public Contact()
        {
            this.ApplicationUserContacts=new HashSet<ApplicationUserContact>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; }=null!;
        [Required]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; }=null!;

        [Required]
        [MaxLength(EmailMaxLegnth)]
        public string Email { get; set; }=null!;

        [Required]
        [MaxLength(PhoneMaxLength)]
        public string PhoneNumber { get; set; }=null!;

        public string? Address { get; set; }

        [Required]
        public string Website { get; set; }=null!;

        public ICollection<ApplicationUserContact> ApplicationUserContacts { get; set; }

    }
}
