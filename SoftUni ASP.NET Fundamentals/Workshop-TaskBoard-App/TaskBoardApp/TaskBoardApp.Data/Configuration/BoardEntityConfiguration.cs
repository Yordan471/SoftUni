using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoardApp.Data.Models;

namespace TaskBoardApp.Data.Configuration
{
    internal class BoardEntityConfiguration : IEntityTypeConfiguration<Board>
    {
        public void Configure(EntityTypeBuilder<Board> builder)
        {
            ICollection<Board> boards = GenerateBoards();

            builder
                .HasData(boards);
        }

        private ICollection<Board> GenerateBoards()
        {
            ICollection<Board> boards = new HashSet<Board>();

            Board board = new()
            {
                Id = 1,
                Name = "OpenBoard"
            };
            boards.Add(board);

            board = new()
            {
                Id = 2,
                Name = "InProgressBoard"
            };
            boards.Add(board);

            board = new()
            {
                Id = 3,
                Name = "DoneBoard"
            };
            boards.Add(board);

            return boards;
        }
    }
}
