using Watchlist.Data.Models;
using Watchlist.ViewModels.MovieViewModels;

namespace Watchlist.Services.Contracts
{
    public interface IMovieService
    {
        public Task<ICollection<MovieViewModel>> GetAllMoviesAsync();

        public Task<ICollection<MovieViewModel>> GetAllWatchedMoviesAsync(string userId);

        public Task AddMovieAndSaveDbAsync(Movie movie);
    }
}
