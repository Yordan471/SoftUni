
namespace Theatre.Data
{
    using Microsoft.EntityFrameworkCore;

    public class TheatreContext : DbContext
    {
        public TheatreContext() 
        {
        }

        public TheatreContext(DbContextOptions options)
        : base(options) 
        { 
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }
    }
}