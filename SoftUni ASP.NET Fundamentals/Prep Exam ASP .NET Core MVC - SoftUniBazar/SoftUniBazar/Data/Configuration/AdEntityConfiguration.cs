using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftUniBazar.Data.Models;

namespace SoftUniBazar.Data.Configuration
{
    public class AdEntityConfiguration : IEntityTypeConfiguration<Ad>
    {
        public void Configure(EntityTypeBuilder<Ad> builder)
        {
            builder
                .Property(a => a.Price)
                .HasPrecision(18, 2);
        }
    }
}
