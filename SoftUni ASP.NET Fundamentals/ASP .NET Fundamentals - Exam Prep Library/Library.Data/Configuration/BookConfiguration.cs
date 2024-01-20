using Library.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Data.Configuration
{
    public class BookConfiguration
    {
        public void Configuration(EntityTypeBuilder<Book> builder)
        {
            builder
                .HasOne(b => b.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(b => b.Rating)
                .HasPrecision(18, 2);
        }
    }
}
