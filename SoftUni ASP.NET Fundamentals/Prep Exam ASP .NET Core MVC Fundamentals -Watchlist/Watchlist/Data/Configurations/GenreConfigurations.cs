using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Watchlist.Data.Models;

namespace Watchlist.Data.Configurations
{
    public class GenreConfigurations : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder
                .HasData(new Genre()
                {
                    Id = 1,
                    Name = "Action"
                },
                new Genre()
                {
                    Id = 2,
                    Name = "Comedy"
                },
                new Genre()
                {
                    Id = 3,
                    Name = "Drama"
                },
                new Genre()
                {
                    Id = 4,
                    Name = "Horror"
                },
                new Genre()
                {
                    Id = 5,
                    Name = "Romantic"
                });
        }
    }
}
