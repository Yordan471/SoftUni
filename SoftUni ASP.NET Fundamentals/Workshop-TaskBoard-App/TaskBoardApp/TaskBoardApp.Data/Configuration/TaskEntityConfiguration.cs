using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TaskBoardApp.Data.Models;
using Task = TaskBoardApp.Data.Models.Task;

namespace TaskBoardApp.Data.Configuration
{
    internal class TaskEntityConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder
                .HasOne(t => t.Board)
                .WithMany(b => b.Tasks)
                .HasForeignKey(t => t.BoardId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasData(this.GenerateTasks());
        }

        internal ICollection<Task> GenerateTasks()
        {
            ICollection<Task> tasks = new HashSet<Task>()
            {
                new Task
                {
                    Id = 1,
                    Title = "Improve CSS Styles",
                    Description = "Implement better styling for all public pages",
                    OwnerId = "1d8385c6-330f-4549-bf3b-9b2eef2ebf76",
                    BoardId = 1
                },
                new Task
                {
                    Id = 2,
                    Title = "Android Client App",
                    Description = "Create Android Client App",
                    OwnerId = "83a769e2-dfb5-4e05-91c3-52e0e1d89b38",
                    BoardId = 2
                },
                new Task
                {
                    Id = 3,
                    Title = "Desctop Client App",
                    Description = "Create Windows Forms",
                    OwnerId = "98948336-7b10-4d64-8e7f-f247e03e5a50",
                    BoardId = 3
                },
                new Task
                {
                    Id = 4,
                    Title = "Create Tasks",
                    Description = "Implement [Create Task] page",
                    OwnerId = "83a769e2-dfb5-4e05-91c3-52e0e1d89b38",
                    BoardId = 2
                }
            };

            return tasks;
        }
    }
}
