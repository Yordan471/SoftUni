using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SoftUniBazar.Data.Configuration;
using SoftUniBazar.Data.Models;
using System.Reflection;

namespace SoftUniBazar.Data
{
    public class BazarDbContext : IdentityDbContext
    {
        public BazarDbContext(DbContextOptions<BazarDbContext> options)
            : base(options)
        {
        }

        public DbSet<Ad> Ads { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<AdBuyer> AdsBuyers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Category>()
                .HasData(new Category()
                {
                    Id = 1,
                    Name = "Books"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Cars"
                },
                new Category()
                {
                    Id = 3,
                    Name = "Clothes"
                },
                new Category()
                {
                    Id = 4,
                    Name = "Home"
                },
                new Category()
                {
                    Id = 5,
                    Name = "Technology"
                });


            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.
                GetAssembly(typeof(BazarDbContext)));

            base.OnModelCreating(modelBuilder);
        }
    }
}