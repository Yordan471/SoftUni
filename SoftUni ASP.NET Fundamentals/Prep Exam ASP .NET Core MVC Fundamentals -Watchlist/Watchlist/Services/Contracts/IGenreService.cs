using Watchlist.ViewModels.GenreViewModel;

namespace Watchlist.Services.Contracts
{
    public interface IGenreService
    {
        public Task<IEnumerable<AllGenreViewModel>> GetAllGenresAsync();
    }
}
