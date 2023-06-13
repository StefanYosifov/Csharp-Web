namespace Contacts.Models.Contacts
{
    using System.ComponentModel.DataAnnotations;

    using static GlobalConstants.GlobalConstants.ContactConstants;
    public class AddContactViewModel
    {
        [Required]
        [StringLength(FirstNameMaxLength,MinimumLength =FirstNameMinLength)]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [StringLength(LastNameMaxLength,MinimumLength = LastNameMinLength)]        
        public string LastName { get; set; } = string.Empty;

        [Required]
        [MaxLength(EmailMaxLegnth)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [RegularExpression(RegexPhoneValidator)]
        public string PhoneNumber { get; set; } = string.Empty;

        public string? Address { get; set; } = string.Empty;

        [Required]
        [RegularExpression(RegexWebsiteValidator)]
        public string Website { get; set; } = string.Empty;
    }
}
