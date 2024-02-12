using Watchlist.ViewModels.MovieViewModels;

namespace Watchlist.Services.Contracts
{
    public interface IMovieService
    {
        public Task<ICollection<MovieViewModel>> GetAllMoviesAsync();

        public Task<ICollection<MovieViewModel>> GetAllWatchedMoviesAsync(userId);
    }
}
