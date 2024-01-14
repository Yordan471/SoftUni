using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoardApp.Data;
using TaskBoardApp.Services.Contracts;
using TaskBoardApp.Web.ViewModels.Board;
using TaskBoardApp.Web.ViewModels.Task;

namespace TaskBoardApp.Services
{
    public class BoardService : IBoardService
    {
        private readonly TaskBoardAppDbContext taskBoardDbContext;

        public BoardService(TaskBoardAppDbContext taskBoardDbContext)
        {
            this.taskBoardDbContext = taskBoardDbContext;
        }

        public async Task<IEnumerable<BoardAllViewModel>> AllAsync()
        {
            return await taskBoardDbContext.Boards
                .Select(b => new BoardAllViewModel
                {
                    Name = b.Name,
                    Tasks = b.Tasks.Select(t => new TaskViewModel
                    {
                        Id = t.Id,
                        Title = t.Title,
                        Description = t.Description,
                        Owner = t.Owner.UserName
                    }).ToArray()
                }).ToArrayAsync();

            // If We want to take only tasks for certain owner then
            // We give as argument in AllAsync(string ownerId)
            //Add Where(t => t.OwnerId = ownerId)
        }

        public async Task<bool> ExistingByIdAsync(int id)
        {
            return await taskBoardDbContext.Boards
                .AnyAsync(b => b.Id == id);
        }

        public async Task<IEnumerable<BoardSelectModel>> SelectAllBoardAsync()
        {
            ICollection<BoardSelectModel> selectAllBoards = await taskBoardDbContext.Boards
                .Select(b => new BoardSelectModel
                {
                    Id = b.Id,
                    Name = b.Name,
                })
                .ToArrayAsync();

            return selectAllBoards;
        }
    }
}
