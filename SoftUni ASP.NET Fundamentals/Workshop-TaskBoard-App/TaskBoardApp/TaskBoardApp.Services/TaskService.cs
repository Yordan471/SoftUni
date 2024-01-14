using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoardApp.Data;
using TaskBoardApp.Services.Contracts;
using TaskBoardApp.Web.ViewModels.Task;

namespace TaskBoardApp.Services
{
    // Don't forget to register the service in the builder!
    public class TaskService : ITaskService
    {
        private readonly TaskBoardAppDbContext taskBoardDbContext;

        public TaskService(TaskBoardAppDbContext dbContext)
        {
            this.taskBoardDbContext = dbContext;
        }

        public async Task AddTaskAsync(string ownerId, TaskFormModel viewModel)
        {
            Data.Models.Task createTask = new Data.Models.Task()
            {
                Title = viewModel.Title,
                Description = viewModel.Description,
                BoardId = viewModel.BoardId,
                CreateOn = DateTime.UtcNow,
                OwnerId = ownerId,
            };

            await taskBoardDbContext.Tasks.AddAsync(createTask);
            await taskBoardDbContext.SaveChangesAsync();
        }
    }
}
