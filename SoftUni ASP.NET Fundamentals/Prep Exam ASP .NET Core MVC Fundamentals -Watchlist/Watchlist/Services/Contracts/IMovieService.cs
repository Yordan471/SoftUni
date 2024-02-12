using Watchlist.Data.Models;
using Watchlist.ViewModels.MovieViewModels;

namespace Watchlist.Services.Contracts
{
    public interface IMovieService
    {
        public Task<ICollection<MovieViewModel>> GetAllMoviesAsync();

        public Task<ICollection<MovieViewModel>> GetAllWatchedMoviesAsync(string userId);

        public Task AddMovieAndSaveDbAsync(Movie movie);

        public Task<bool> CheckIfMovieIdExistsInDbAsync(int id);

        public Task<bool> CheckIfUserMovieExistsInDbAsync(UserMovie userMovie);

        public Task AddUserMovieToDbAsync(UserMovie userMovie);

        public Task AddEntityToDbAsync<T>(T entity);
    }
}
