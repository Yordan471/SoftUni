using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TaskBoardApp.Data.Models;
using Task = TaskBoardApp.Data.Models.Task;
namespace TaskBoardApp.Data
{
    public class TaskBoardAppDbContext : IdentityDbContext<IdentityUser>
    {
        public TaskBoardAppDbContext(DbContextOptions<TaskBoardAppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Task> Tasks { get; set; }

        public DbSet<Board> Boards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.
                GetAssembly(typeof(TaskBoardAppDbContext)));

            base.OnModelCreating(modelBuilder);
        }
    }
}
