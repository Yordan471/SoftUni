using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftUniBazar.Data.Models;

namespace SoftUniBazar.Data.Configuration
{
    public class AdBuyerConfiguration : IEntityTypeConfiguration<AdBuyer>
    {
        public void Configure(EntityTypeBuilder<AdBuyer> builder)
        {
            builder
                .HasKey(ab => new { ab.BuyerId, ab.AdId });
        }
    }
}
