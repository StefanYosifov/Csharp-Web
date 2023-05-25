namespace Watchlist.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Movie
    {
        public Movie()
        {
            this.UsersMovies = new HashSet<UserMovie>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.MovieTitleMax)]
        public string Title { get; set; }

        [Required]
        [MaxLength(GlobalConstants.MovieDirectorMax)]
        public string Director { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [Range(GlobalConstants.MovieRatingMin,GlobalConstants.MovieRatingMax)]
        public decimal Rating { get; set; }

        [Required]
        [ForeignKey(nameof(Genre))]
        public int GenreId { get; set; }
        [Required]
        public virtual Genre Genre { get; set; }

        public ICollection<UserMovie> UsersMovies { get; set; }


    }
}
