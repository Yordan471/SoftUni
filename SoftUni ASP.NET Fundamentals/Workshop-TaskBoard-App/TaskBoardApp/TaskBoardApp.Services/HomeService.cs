using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoardApp.Data;
using TaskBoardApp.Services.Contracts;
using TaskBoardApp.Web.ViewModels.Home;

namespace TaskBoardApp.Services
{
    public class HomeService : IHomeService
    {
        private readonly TaskBoardAppDbContext dbContext;

        public HomeService(TaskBoardAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<string>> GetAllBoardNames()
        {
            var boardNames = await dbContext.Boards
                .Select(b => b.Name)
                .Distinct()
                .ToArrayAsync();

            return boardNames;
        }

        public async Task<ICollection<HomeBoardModel>> GetAllTasksForBoards(Task<IEnumerable<string>> boardNames)
        {
            ICollection<HomeBoardModel> tasksInBoard = new HashSet<HomeBoardModel>();

            foreach (var boardName in await boardNames)
            {
                int tasksCount = await dbContext.Tasks
                .Where(t => t.Board.Name == boardName)
                .CountAsync();

                tasksInBoard.Add(new HomeBoardModel
                {
                    BoardName = boardName,
                    TaskCount = tasksCount
                });
            }

            return tasksInBoard;
        }
    }
}
