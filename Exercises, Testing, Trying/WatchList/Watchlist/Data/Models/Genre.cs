namespace Watchlist.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Genre
    {
        public Genre()
        {
            this.Movies = new HashSet<Movie>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.GenreNameMax)]
        public string Name { get; set; }

        public ICollection<Movie> Movies { get; set; }

    }
}
