namespace Homies.Models.EventModels
{
    using System.ComponentModel.DataAnnotations;

    using static GlobalConstants.GlobalConstants.EventConstants;

    public class EventAddViewModel
    {
        public EventAddViewModel()
        {
            Types = new List<TypeViewModel>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(EventNameMaxLength,MinimumLength = EventNameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(EventDescriptionMaxLength,MinimumLength = EventDescriptionMinLength)]
        public string Description { get; set; } = null!;
        public string? OrganiserId { get; set; } = null!;

        public string? Organiser { get; set; } = null!;

        public string? CreatedOn { get; set; }

        [Required] public string Start { get; set; }

        [Required] public string End { get; set; }

        [Required] public int TypeId { get; set; }

        public IEnumerable<TypeViewModel> Types { get; set; }
    }
}
