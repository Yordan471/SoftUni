using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Watchlist.Common.EntityValidationsConstants.User;
using Watchlist.Data.Models;
using Microsoft.AspNetCore.Identity;


namespace Watchlist.Data.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .Property(u => u.UserName)
                .HasMaxLength(UserNameMaxLength)
                .IsRequired();
                
            builder
                .Property(u => u.Email)
                .HasMaxLength(EmailMaxLength)
                .IsRequired();
        }
    }
}
