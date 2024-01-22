using Library.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Library.Extensions;
using Library.Models.BookViewModels;
using Library.Models;

namespace Library.Controllers
{
    public class BookController : BaseController
    {

        private readonly IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        public async Task<IActionResult> All()
        {
            IEnumerable<AllBookViewModel> allBooks = await bookService.GetAllBooksAsync();

            return View(allBooks);
        }

        public async Task<IActionResult> Mine()
        {
            string userId = ClaimsPrincipleExtensions.GetId(User);

            ICollection<MineBookViewModel> allBooks = await bookService.GetMineBooksAsync(userId);

            return View(allBooks);
        }

        public async Task<IActionResult> AddToCollection(int id)
        {
            string userId = ClaimsPrincipleExtensions.GetId(User);

            //if (userId == null)
            //{
            //    throw new ArgumentNullException(nameof(userId));
            //}

            BookViewModel bookViewModel = await bookService.GetBookByIdAsync(id);

            if (bookViewModel == null)
            {
                return RedirectToAction(nameof(All));
            }

            await bookService.AddBookToCollectionAsync(userId, bookViewModel);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            AddBookViewModel addBookViewModel = await
                bookService.AddNewBookViewModelWithCategories();

            return View(addBookViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBookViewModel addBookViewModel)
        {
            decimal rating;

            if (!decimal.TryParse(addBookViewModel.Rating, out rating) || rating < 0 || rating > 10)
            {
                ModelState.AddModelError(nameof(addBookViewModel.Rating),
                    "Rating must be a number between 0 and 10");
                addBookViewModel = await
                bookService.AddNewBookViewModelWithCategories();
                return View(addBookViewModel);
            }

            if (!ModelState.IsValid)
            {
                addBookViewModel = await
                bookService.AddNewBookViewModelWithCategories();
                return View(addBookViewModel);
            }

            await bookService.AddBookToAllAsync(addBookViewModel);

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> RemoveFromCollection(int id)
        {
            string userId = ClaimsPrincipleExtensions.GetId(User);
            var book = await bookService.GetBookByIdAsync(id);

            if (book == null)
            {
                return RedirectToAction(nameof(Mine));
            }

            await bookService.RemoveBookViewModelByIdAsync(userId, id);

            return RedirectToAction(nameof(Mine));
        }
    }
}
