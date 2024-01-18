using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskBoardApp.Web.ViewModels.Home
{
    public class HomeViewModel
    {
        public int AllTasksCount { get; set; }

        public ICollection<HomeBoardModel> BoardsWithTasksCount { get; set; } = null!;

        public int UserTasksCount { get; set; }
    }
}
