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

        Task<TaskDetailsViewModel> GetForDetailsByIdAsync(int Id);

        Task<Data.Models.Task> GetTaskByIdAsync(int id);

        Task EditedTaskAsync(Data.Models.Task task, TaskFormModel viewModel);

        Task DeleteTaskAsync(Data.Models.Task task);

        Task<int> GetTasksCountForUser(string userId);

        Task<int> GetTasksCount();
    }
}
