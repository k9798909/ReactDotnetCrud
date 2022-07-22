using Microsoft.EntityFrameworkCore;
using RestfulApi.Models;

namespace RestfulApi.Context
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        { 
        }

        public DbSet<Product> Product { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
        }


    }
}
