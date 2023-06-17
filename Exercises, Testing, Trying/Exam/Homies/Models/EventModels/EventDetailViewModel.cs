namespace Homies.Models.EventModels
{
    using System.ComponentModel.DataAnnotations;
    using static GlobalConstants.GlobalConstants.EventConstants;

    public class EventDetailViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(EventNameMaxLength, MinimumLength = EventNameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(EventDescriptionMaxLength, MinimumLength = EventDescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required] public string Organiser { get; set; } = null!;

        [Required] public string CreatedOn { get; set; }= null!;

        [Required] public string Start { get; set; }= null!;

        [Required] public string End { get; set; }= null!;

        [Required] public string Type { get; set; } = null!;
    }
}