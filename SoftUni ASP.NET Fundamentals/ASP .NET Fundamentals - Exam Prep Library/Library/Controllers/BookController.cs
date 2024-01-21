using Library.Contracts;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Library.Extensions;

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

            IEnumerable<MineBookViewModel> allBooks = await bookService.GetMineBooksAsync(userId);

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
    }
}
