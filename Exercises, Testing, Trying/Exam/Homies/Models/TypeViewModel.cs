namespace Homies.Models
{
    using System.ComponentModel.DataAnnotations;
    using static GlobalConstants.GlobalConstants.TypeConstants;

    public class TypeViewModel
    {

        public int Id { get; set; }

        [StringLength(TypeNameMaxLength, MinimumLength = TypeNameMinLength)]
        public string Name { get; set; } = null!;

    }
}
