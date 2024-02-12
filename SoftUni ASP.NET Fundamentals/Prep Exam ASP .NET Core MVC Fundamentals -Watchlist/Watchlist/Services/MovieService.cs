using Microsoft.EntityFrameworkCore;
using Watchlist.Data;
using Watchlist.Data.Models;
using Watchlist.Services.Contracts;
using Watchlist.ViewModels.MovieViewModels;

namespace Watchlist.Services
{
    public class MovieService : IMovieService
    {
        private readonly WatchlistDbContext dbContext;

        public MovieService(WatchlistDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddMovieAndSaveDbAsync(Movie movie)
        {
            await dbContext.AddAsync(movie);
            await dbContext.SaveChangesAsync();
        }

        public async Task<ICollection<MovieViewModel>> GetAllMoviesAsync()
        {
            return await dbContext.Movies.Include(m => m.Genre).Select(m => new MovieViewModel()
            {
                Id = m.Id,
                Title = m.Title,
                Director = m.Director,
                ImageUrl = m.ImageUrl,
                Rating = m.Rating,
                Genre = m.Genre.Name
            }).AsNoTracking()
            .ToArrayAsync();
        }

        public Task<ICollection<MovieViewModel>> GetAllWatchedMoviesAsync(string userId)
        {
            return dbContext.Movies
                .Where(m => m.UsersMovies.Where(um => um.UserId == userId))
                .Select(m => new MovieViewModel())
        }
    }
}
