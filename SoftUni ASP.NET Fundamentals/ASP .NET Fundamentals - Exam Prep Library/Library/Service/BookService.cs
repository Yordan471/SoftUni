using Library.Contracts;
using Library.Data;
using Library.Data.Models;
using Library.Models.BookViewModels;
using Library.Models.CategoryViewModels;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Service
{
    public class BookService : IBookService
    {
        private readonly LibraryDbContext dbContext;

        public BookService(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddBookToAllAsync(AddBookViewModel addBookViewModel)
        {
            Book book = new Book
            {
                Title = addBookViewModel.Title,
                Author = addBookViewModel.Author,
                Description = addBookViewModel.Description,
                Rating = decimal.Parse(addBookViewModel.Rating),
                ImageUrl = addBookViewModel.Url,
                CategoryId = addBookViewModel.CategoryId
            };

            await dbContext.Books.AddAsync(book);
            await dbContext.SaveChangesAsync();
        }

        public async Task AddBookToCollectionAsync(string userId, BookViewModel bookViewModel)
        {
            bool alreadyExistingBook = await dbContext.UsersBooks
                .Where(ub => ub.CollectorId == userId && ub.BookId == bookViewModel.Id)
                .AnyAsync();

            if (!alreadyExistingBook)
            {
                IdentityUserBook userBook = new()
                {
                    CollectorId = userId,
                    BookId = bookViewModel.Id,
                };

                await dbContext.UsersBooks.AddAsync(userBook);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<AddBookViewModel> AddNewBookViewModelWithCategories()
        {
            ICollection<CategoryViewModel> categories = await dbContext.Categories
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                }).ToArrayAsync();

            AddBookViewModel viewModel = new AddBookViewModel
            {
                Categories = categories
            };

            return viewModel;
        }

        public async Task<IEnumerable<AllBookViewModel>> GetAllBooksAsync()
        {
            return await dbContext.Books
                .Select(ub => new AllBookViewModel
                {
                    Id = ub.Id,
                    Title = ub.Title,
                    Author = ub.Author,
                    ImageUrl = ub.ImageUrl,
                    Rating = ub.Rating,
                    Category = ub.Category.Name
                }).ToArrayAsync();
        }

        public async Task<BookViewModel?> GetBookByIdAsync(int id)
        {
            return await dbContext.Books
                .Where(b => b.Id == id)
                .Select(b => new BookViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    ImageUrl = b.ImageUrl,
                    Rating = b.Rating,
                    CategoryId = b.CategoryId
                }).FirstOrDefaultAsync();
        }

        public async Task<ICollection<MineBookViewModel>> GetMineBooksAsync(string id)
        {
            return await dbContext.UsersBooks
                .Where(ub => ub.CollectorId == id)
                .Select(ub => new MineBookViewModel
                {
                    Id = ub.Book.Id,
                    Title = ub.Book.Title,
                    Author = ub.Book.Author,
                    ImageUrl = ub.Book.ImageUrl,
                    Description = ub.Book.Description,
                    Category = ub.Book.Category.Name
                }).ToArrayAsync();
        }

        public async Task RemoveBookViewModelByIdAsync(string userId, int bookId)
        {
            var removeBook = await dbContext.UsersBooks
                .FirstOrDefaultAsync(ub => ub.CollectorId == userId && ub.BookId == bookId);

            if (removeBook != null)
            {
                dbContext.UsersBooks.Remove(removeBook);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
