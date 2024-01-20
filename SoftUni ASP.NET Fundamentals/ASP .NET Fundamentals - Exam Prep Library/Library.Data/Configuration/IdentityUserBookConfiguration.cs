using Microsoft.EntityFrameworkCore;
using Library.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Data.Configuration
{
    public class IdentityUserBookConfiguration
    {
        protected void Configure(EntityTypeBuilder<IdentityUserBook> builder)
        {
            builder
                .HasKey(iub => new { iub.CollectorId, iub.BookId });
        }
    }
}
