using Microsoft.EntityFrameworkCore;
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

        public async void EditedTaskAsync(Data.Models.Task task, TaskFormModel viewModel)
        {
            task.Title = viewModel.Title;
            task.Description = viewModel.Description;
            task.BoardId = viewModel.BoardId;

            await taskBoardDbContext.SaveChangesAsync();
        }

        public async Task<TaskDetailsViewModel> GetForDetailsByIdAsync(int id)
        {
            TaskDetailsViewModel? viewModel = await this.taskBoardDbContext
                .Tasks
                .Where(t => t.Id == id)
                .Select(t => new TaskDetailsViewModel
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    Owner = t.Owner.UserName,
                    CreatedOn = t.CreateOn.ToString("f"),
                    Board = t.Board.Name
                })
                .FirstOrDefaultAsync();

            return viewModel;
        }

        public async Task<Data.Models.Task> GetTaskByIdAsync(int id)
        {
            Data.Models.Task task = await taskBoardDbContext.Tasks.FindAsync(id);

            return task;
        }
    }
}
