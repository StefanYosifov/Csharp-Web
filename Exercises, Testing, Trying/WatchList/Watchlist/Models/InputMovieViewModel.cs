namespace Watchlist.Models
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models;

    public class InputMovieViewModel
    {

        public InputMovieViewModel()
        {
            this.Genres=new List<Genre>();
        }

        [Required]
        [MaxLength(GlobalConstants.MovieTitleMax)]
        public string Title { get; set; }

        [Required]
        [MaxLength(GlobalConstants.MovieDirectorMax)]
        public string Director { get; set; }

        [Required]
        [Url]
        public string ImageUrl { get; set; }

        [Required]
        [Range(GlobalConstants.MovieRatingMin, GlobalConstants.MovieRatingMax)]
        public decimal Rating { get; set; }

        public int GenreId { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

    }
}
