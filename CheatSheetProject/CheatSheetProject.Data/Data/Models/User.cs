namespace CheatSheetProject.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public User()
        {
            this.Resources = new HashSet<Resource>();
        }


        [Key]
        public int Id { get; set; }

        [MaxLength(ModelConstants.UserNameMaxLength)]
        public string Name { get; set; } = null!;

        [MaxLength(ModelConstants.UserEmailMaxLength)]
        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public ICollection<Resource>? Resources { get; set; }

    }
}
