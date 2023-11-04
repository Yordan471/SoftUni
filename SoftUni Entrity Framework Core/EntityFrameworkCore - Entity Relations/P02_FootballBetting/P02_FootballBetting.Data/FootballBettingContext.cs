using Microsoft.EntityFrameworkCore;
using P02_FootballBetting.Data.Models;

namespace P02_FootballBetting.Data
{
    public class FootballBettingContext : DbContext
    {

        public FootballBettingContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }


        private const string ConnectionString = 
            "Server=DESKTOP-U0UT8KF\\SQLEXPRESS;Database=FootballBetting;Trusted_Connection=True;TrustServerCertificate=True";


        public DbSet<Town> Towns { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Position> Positions { get; set; }
        //not added as migration
        public DbSet<Color> Colors { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Bet> Bets { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<PlayerStatistic> PlayersStatistics { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(ConnectionString);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerStatistic>()
                .HasKey(ps => new { ps.PlayerId, ps.GameId });
        }
    }
}
