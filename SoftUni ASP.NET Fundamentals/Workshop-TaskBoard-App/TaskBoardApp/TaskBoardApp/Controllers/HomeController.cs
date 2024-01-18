using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TaskBoardApp.Extensions;
using TaskBoardApp.Services.Contracts;
using TaskBoardApp.Web.ViewModels.Home;

namespace TaskBoardApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService homeService;
        private readonly ITaskService taskService;

        public HomeController(IHomeService homeService, ITaskService taskService)
        {
            this.homeService = homeService;
            this.taskService = taskService;
        }

        public async Task<IActionResult> Index()
        {
            var boardNames = homeService.GetAllBoardNames();

            ICollection<HomeBoardModel> tasksCounts = 
                await homeService.GetAllTasksForBoards(boardNames);

            int userTasksCount = -1;

            if (User.Identity.IsAuthenticated)
            {
                var currentUserId = ClaimsPrincipleExtensions.GetId(User);
                userTasksCount = await taskService.GetTasksCountForUser(currentUserId);
            }

            HomeViewModel viewModel = new HomeViewModel
            {
                AllTasksCount = await taskService.GetTasksCount(),
                BoardsWithTasksCount = tasksCounts,
                UserTasksCount = userTasksCount
            };

            return View(viewModel);
        }
    }
}
