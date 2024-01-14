using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskBoardApp.Data;
using TaskBoardApp.Extensions;
using TaskBoardApp.Services;
using TaskBoardApp.Services.Contracts;
using TaskBoardApp.Web.ViewModels.Task;
using static TaskBoardApp.Extensions.ClaimsPrincipleExtensions;

namespace TaskBoardApp.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        private readonly IBoardService boardService;
        private readonly ITaskService taskService;

        public TaskController(IBoardService boardService, ITaskService taskService)
        {
            this.boardService = boardService;
            this.taskService = taskService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            TaskFormModel viewModel = new()
            {
                Boards = await boardService.SelectAllBoardAsync()
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskFormModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Boards = await this.boardService.SelectAllBoardAsync();
                return View(viewModel);
            }

            // Check if board Id is existing in the db
            bool boardExists = await this.boardService.ExistingByIdAsync(viewModel.BoardId);
            if (!boardExists)
            {
                viewModel.Boards = await boardService.SelectAllBoardAsync();
                ModelState.AddModelError(nameof(viewModel.BoardId), "Selected board doesn't exist!");
               
                return View(viewModel);
            }

            // Get user Id with ClaimPrincipalExtensions
            string userId = this.User.GetId();

            await this.taskService.AddTaskAsync(userId, viewModel);

            return RedirectToAction("All", "Board");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                TaskDetailsViewModel viewModel =
                    await this.taskService.GetForDetailsByIdAsync(id);

                return this.View(viewModel);
            }
            catch (Exception)
            {
                return this.RedirectToAction("All", "Board");
            }
        }
    }
}
