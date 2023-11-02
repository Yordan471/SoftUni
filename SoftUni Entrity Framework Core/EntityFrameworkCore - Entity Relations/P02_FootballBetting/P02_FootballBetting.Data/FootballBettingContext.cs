using Microsoft.EntityFrameworkCore;
using P02_FootballBetting.Data.Models;

namespace P02_FootballBetting.Data
{
    public class FootballBettingContext : DbContext
    {
        private const string ConnectionString = 
            "Server=DESKTOP-U0UT8KF\\SQLEXPRESS;Database=FootballBetting;Trusted_Connection=True;TrustServerCertificate=True";

        public DbSet<Town> Towns { get; set; }

        public DbSet<Country> Countries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
