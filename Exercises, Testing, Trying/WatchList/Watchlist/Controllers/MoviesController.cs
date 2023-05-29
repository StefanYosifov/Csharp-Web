namespace Watchlist.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Models;
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

        public async Task<IActionResult> Add()
        {
            var genres = new InputMovieViewModel()
            {
                Genres = await service.GetGenreAsync()
            };
            
            return View(genres);
        }

        [HttpPost]
        public async Task<IActionResult> Add(InputMovieViewModel movieModel)
        {
            if (!ModelState.IsValid)
            {
                return View(movieModel);
            }

            try
            {
                
                await service.AddMovieAsync(movieModel);
                return RedirectToAction(nameof(All));
            }
            catch (Exception e)
            {
               ModelState.AddModelError("","Something went wrong");
               return View(movieModel);
            }
        }

        public async Task<IActionResult> AddToCollection(int movieId)
        {
            var userId=HttpContext.User.Claims.
        }

    }
}
