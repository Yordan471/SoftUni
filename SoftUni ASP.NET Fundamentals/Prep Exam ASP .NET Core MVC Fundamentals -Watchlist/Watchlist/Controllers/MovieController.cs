using Microsoft.AspNetCore.Mvc;
using Watchlist.Services.Contracts;

namespace Watchlist.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService movieService;

        public MovieController(IMovieService movieService) 
        {
            this.movieService = movieService;
        }
        public async Task<IActionResult> All()
        {
            var movies = await movieService.GetAllMoviesAsync();

            return View(movies);
        }
    }
}
