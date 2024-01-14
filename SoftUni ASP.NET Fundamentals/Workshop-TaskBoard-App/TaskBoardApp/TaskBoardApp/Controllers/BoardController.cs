using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskBoardApp.Services.Contracts;
using TaskBoardApp.Web.ViewModels.Board;

namespace TaskBoardApp.Controllers
{
    [Authorize]
    public class BoardController : Controller
    {
        private readonly IBoardService boardService;

        public BoardController(IBoardService boardService)
        {
            this.boardService = boardService;
        }

        // Get all boards and display them
        [HttpGet]
        public async Task<IActionResult> All()
        {
            IEnumerable<BoardAllViewModel> boardViewModels = 
                await boardService.AllAsync();

            return View(boardViewModels);
        }
    }
}
