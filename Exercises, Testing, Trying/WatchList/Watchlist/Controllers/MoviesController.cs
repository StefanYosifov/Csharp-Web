namespace Watchlist.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services.MovieService;

    public class MoviesController : Controller
    {
        private readonly IMovieService service;

        public MoviesController(IMovieService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var movieResult = await service.GetAllAsync();
            return View(movieResult);
        }

    }
}
