using Watchlist.ViewModels.MovieViewModels;

namespace Watchlist.Services.Contracts
{
    public interface IMovieService
    {
        public Task<ICollection<MovieViewModel>> GetAllMoviesAsync();
    }
}
