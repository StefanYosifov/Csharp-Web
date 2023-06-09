namespace Library.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static GlobalConstants.GlobalConstants.CategoryConstants;

    public class Category
    {
        public Category()
        {
            Books = new HashSet<Book>();
        }

        [Key] public int Id { get; set; }

        [Required]
        [MaxLength(CategoryNameMaxLength)]
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}