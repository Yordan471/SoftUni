using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Watchlist.Data.Configurations;
using Watchlist.Data.Models;

namespace Watchlist.Data
{
    public class WatchlistDbContext : IdentityDbContext<User>
    {
        public WatchlistDbContext(DbContextOptions<WatchlistDbContext> options)
            : base(options)
        {
        }
        public DbSet<Movie> Movies { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<UserMovie> UsersMovies { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserMovieConfigurations());
            builder.ApplyConfiguration(new UserConfigurations());
            builder.ApplyConfiguration(new MovieConfigurations());
            builder.ApplyConfiguration(new GenreConfigurations());
            
            base.OnModelCreating(builder);
        }
    }
}