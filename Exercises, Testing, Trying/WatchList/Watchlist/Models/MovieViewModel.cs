namespace Watchlist.Models
{
    using System.ComponentModel.DataAnnotations;

    public class MovieViewModel
    {

        public int Id { get; set; }

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

        public string Genre { get; set; }

    }
}
