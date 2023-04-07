namespace Eventmi.Infrastructure.Data.Data_Models
{
    using Eventmi.Infrastructure.Data.Common;
    using System.ComponentModel.DataAnnotations;

    public class Event 
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.EventNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }

        [Required]
        public string Places { get; set; } = null!;

    }
}
