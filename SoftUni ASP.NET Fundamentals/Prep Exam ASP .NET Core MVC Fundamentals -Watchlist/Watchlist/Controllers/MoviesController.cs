using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Watchlist.Data.Models;
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

        [HttpPost]
        public async Task<IActionResult> Add(AddMovieViewModel addMovieViewModel)
        {
            var allGenres = await genreService.GetAllGenresAsync();

            if (!allGenres.Any(g => g.Id == addMovieViewModel.GenreId))
            {
                ModelState.AddModelError("GenreId", "Genre does not exist!");
            }

            if (!ModelState.IsValid)
            {
                addMovieViewModel.Genres = allGenres;

                return View(addMovieViewModel);
            }

            var movie = new Movie()
            {
                Title = addMovieViewModel.Title,
                Director = addMovieViewModel.Director,
                ImageUrl = addMovieViewModel.ImageUrl,
                Rating = addMovieViewModel.Rating,
                GenreId = addMovieViewModel.GenreId
            };

            await movieService.AddMovieAndSaveDbAsync(movie);

            return RedirectToAction(nameof(All));
        }
    }
}
