using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Watchlist.Services.Contracts;

namespace Watchlist.Controllers
{
    [Authorize]
    public class MoviesController : Controller
    {
        private readonly IMovieService movieService;

        public MoviesController(IMovieService movieService) 
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
