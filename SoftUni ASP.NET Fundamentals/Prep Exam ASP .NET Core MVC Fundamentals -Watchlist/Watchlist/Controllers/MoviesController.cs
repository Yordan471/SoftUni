using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Watchlist.Extensions;
using Watchlist.Services.Contracts;
using Watchlist.ViewModels.MovieViewModels;

namespace Watchlist.Controllers
{
    [Authorize]
    public class MoviesController : Controller
    {
        private readonly IMovieService movieService;
        private readonly IGenreService genreService;

        public MoviesController(IMovieService movieService, IGenreService genreService) 
        {
            this.movieService = movieService;
            this.genreService = genreService;
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var movies = await movieService.GetAllMoviesAsync();

            return View(movies);
        }

        [HttpGet]
        public async Task<IActionResult> Watched()
        {
            string userId = ClaimsPrincipleExtensions.GetId(this.User);

            var watchedMovies = movieService.GetAllWatchedMoviesAsync(userId);

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var allGenres = await genreService.GetAllGenresAsync();

            if (allGenres == null)
            {
                return BadRequest();
            }

            var addMovieViewModel = new AddMovieViewModel()
            {
                Genres = allGenres
            };

            return View(addMovieViewModel);
        }
    }
}
