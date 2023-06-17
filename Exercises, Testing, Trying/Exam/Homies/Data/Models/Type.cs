namespace Homies.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static GlobalConstants.GlobalConstants.TypeConstants;

    public class Type
    {
        public Type()
        {
            Events = new HashSet<Event>();
        }

        [Key] public int Id { get; set; }

        [Required]
        [MaxLength(TypeNameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<Event> Events { get; set; }
    }
}