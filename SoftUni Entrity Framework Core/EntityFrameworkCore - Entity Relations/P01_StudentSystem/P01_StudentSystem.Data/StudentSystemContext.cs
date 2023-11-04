using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        //public StudentSystemContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        private const string ConnectionString = "Server=DESKTOP-U0UT8KF\\SQLEXPRESS;Database=StudentSystem;Trusted_Connection=True;TrustServerCertificate=True";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }


        public DbSet<Student> Students { get; set; }
    }
}
