namespace Homies.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.AspNetCore.Identity;

    using static GlobalConstants.GlobalConstants.EventConstants;

    public class Event
    {
        public Event()
        {
            EventParticipants = new HashSet<EventParticipant>();
        }

        [Key] public int Id { get; set; }

        [Required]
        [MaxLength(EventNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(EventDescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required] public string OrganiserId { get; set; } = null!;

        [Required] public IdentityUser Organiser { get; set; } = null!;

        [Required] public DateTime CreatedOn { get; set; }

        [Required] public DateTime Start { get; set; }

        [Required] public DateTime End { get; set; }

        [Required] 
        [ForeignKey(nameof(Type))] 
        public int TypeId { get; set; }

        [Required] public Type Type { get; set; } = null!;

        public ICollection<EventParticipant> EventParticipants { get; set; }
    }
}