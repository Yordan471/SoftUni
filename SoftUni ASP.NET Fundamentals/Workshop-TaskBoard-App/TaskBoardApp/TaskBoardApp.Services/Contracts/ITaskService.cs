using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoardApp.Web.ViewModels.Task;

namespace TaskBoardApp.Services.Contracts
{
    public interface ITaskService
    {
        Task AddTaskAsync(string ownerId, TaskFormModel viewModel);
    }
}
