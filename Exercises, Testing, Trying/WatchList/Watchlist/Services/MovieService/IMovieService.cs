namespace Watchlist.Services.MovieService
{
    using Data.Models;
    using Models;

    public interface IMovieService
    {

        Task<IEnumerable<MovieViewModel>> GetAllAsync();

        Task<IEnumerable<Genre>> GetGenreAsync();

    }
}
