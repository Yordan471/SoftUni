using Library.Models;

namespace Library.Contracts
{
    public interface IBookService
    {
        public Task<IEnumerable<AllBookViewModel>> GetAllBooksAsync();

        public Task<IEnumerable<MineBookViewModel>> GetMineBooksAsync(string id);

        public Task<BookViewModel> GetBookByIdAsync(int id);

        public Task AddBookToCollectionAsync(string userId, BookViewModel bookViewModel);

    }
}
