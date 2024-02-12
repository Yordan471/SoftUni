using Microsoft.EntityFrameworkCore;
using Watchlist.Data;
using Watchlist.Services.Contracts;
using Watchlist.ViewModels.GenreViewModel;

namespace Watchlist.Services
{
    public class GenreService : IGenreService
    {
        private readonly WatchlistDbContext dbContext;

        public GenreService(WatchlistDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<AllGenreViewModel>> GetAllGenresAsync()
        {
            return await dbContext.Genres.Select(g => new AllGenreViewModel()
            {
                Id = g.Id,
                Name = g.Name
            })
            .AsNoTracking()
            .ToArrayAsync();
        }
    }
}
