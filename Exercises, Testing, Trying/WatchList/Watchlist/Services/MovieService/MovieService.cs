namespace Watchlist.Services.MovieService
{
    using Data;
    using Data.Models;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
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

        public async Task<IEnumerable<Genre>> GetGenreAsync()
        {
            return await context.Genres.ToArrayAsync();
        }

        public async Task AddMovieAsync(InputMovieViewModel movieModel)
        {

            if (context.Movies.Any(m => m.Title == movieModel.Title))
            {
                return;
            }

            var movie = new Movie()
            {
                Director = movieModel.Director,
                Title = movieModel.Title,
                ImageUrl = movieModel.ImageUrl,
                Rating = movieModel.Rating,
                GenreId = movieModel.GenreId,
            };

            context.Movies.Add(movie);
            await context.SaveChangesAsync();
        }

        
    }
}
