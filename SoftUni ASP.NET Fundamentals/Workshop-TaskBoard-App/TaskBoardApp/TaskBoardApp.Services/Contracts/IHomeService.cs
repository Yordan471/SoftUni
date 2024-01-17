using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoardApp.Web.ViewModels.Home;

namespace TaskBoardApp.Services.Contracts
{
    public interface IHomeService
    {
        public Task<IEnumerable<string>> GetAllBoardNames();

        public Task<ICollection<HomeBoardModel>> GetAllTasksForBoards(string boardName);
    }
}
