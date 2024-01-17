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
            var boardNames = dbContext.Boards
                .Select(b => b.Name)
                .Distinct();

            return boardNames;
        }

        public Task<ICollection<HomeBoardModel>> GetAllTasksForBoards(string boardName)
        {
            
        }
    }
}
