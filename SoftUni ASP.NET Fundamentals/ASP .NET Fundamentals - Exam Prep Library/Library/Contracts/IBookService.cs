using Library.Models.BookViewModels;

namespace Library.Contracts
{
    public interface IBookService
    {
        public Task<IEnumerable<AllBookViewModel>> GetAllBooksAsync();

        public Task<ICollection<MineBookViewModel>> GetMineBooksAsync(string id);

        public Task<BookViewModel> GetBookByIdAsync(int id);

        public Task AddBookToCollectionAsync(string userId, BookViewModel bookViewModel);

        public Task RemoveBookViewModelByIdAsync(string userId, int bookId);
    }
}
