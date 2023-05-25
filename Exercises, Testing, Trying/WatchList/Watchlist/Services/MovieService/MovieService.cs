namespace Watchlist.Services.MovieService
{
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class MovieService:IMovieService
    {
        private readonly WatchlistDbContext context;

        public MovieService(WatchlistDbContext context)
        {
            this.context = context;
        }


        public async Task<IEnumerable<MovieViewModel>> GetAllAsync()
        {
           return await context.Movies.Select(m => new MovieViewModel()
            {
                Id = m.Id,
                Director = m.Director,
                ImageUrl = m.ImageUrl,
                Rating = m.Rating,
                Title = m.Title,
                Genre = m.Genre.Name
            }).ToArrayAsync();
        }
    }
}
