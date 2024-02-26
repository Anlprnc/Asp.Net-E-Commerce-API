using System.Reflection;
using Asp.Net_E_Commerce.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Asp.Net_E_Commerce.Core.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            SeedInitialData(modelBuilder);
        }

        private void SeedInitialData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, CategoryName = "Electronics", Slug = "electronics", Order = 1, IsActive = true },
                new Category { Id = 2, CategoryName = "Clothing", Slug = "clothing", Order = 2, IsActive = true },
                new Category { Id = 3, CategoryName = "Books", Slug = "books", Order = 3, IsActive = true }
            );

            modelBuilder.Entity<Brand>().HasData(
                new Brand { Id = 1, BrandName = "Sony", IsActive = true },
                new Brand { Id = 2, BrandName = "Nike", IsActive = true },
                new Brand { Id = 3, BrandName = "Penguin Books", IsActive = true }
            );
        }
    }
}