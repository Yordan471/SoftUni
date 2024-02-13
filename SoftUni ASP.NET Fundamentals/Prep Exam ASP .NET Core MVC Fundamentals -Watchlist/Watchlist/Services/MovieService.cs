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

        public async Task AddEntityToDbAsync<T>(T entity)
        {
            await dbContext.AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task AddMovieAndSaveDbAsync(Movie movie)
        {
            await dbContext.AddAsync(movie);
            await dbContext.SaveChangesAsync();
        }

        public async Task AddUserMovieToDbAsync(UserMovie userMovie)
        {
            await dbContext.AddAsync(userMovie);
            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> CheckIfMovieIdExistsInDbAsync(int id)
        {
            return await dbContext.Movies.AnyAsync(m => m.Id == id);
        }

        public async Task<bool> CheckIfUserMovieExistsInDbAsync(UserMovie userMovie)
        {
            return await dbContext.UsersMovies.ContainsAsync(userMovie);
        }

        public async Task<ICollection<MovieViewModel>> GetAllMoviesAsync()
        {
            return await dbContext.Movies
                .Include(m => m.Genre)
                .Select(m => new MovieViewModel()
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

        public async Task<ICollection<MovieViewModel>> GetAllWatchedMoviesAsync(string userId)
        {
            var user = await dbContext.Users
                .Where(u => u.Id == userId)
                .Include(u => u.UsersMovies)
                .ThenInclude(um => um.Movie)
                .ThenInclude(m => m.Genre)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            return user.UsersMovies.Select(m => new MovieViewModel()
            {
                Director = m.Movie.Director,
                Genre = m.Movie.Genre.Name,
                Id = m.MovieId,
                ImageUrl = m.Movie.ImageUrl,
                Title = m.Movie.Title,
                Rating = m.Movie.Rating,
            }).ToArray();
        }

        public async Task RemoveUserMovieFromDbAsync(UserMovie userMovie)
        {
            dbContext.Remove(userMovie);
            await dbContext.SaveChangesAsync();
        }
    }
}
