using appRedis.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace appRedis.Infra.Data;

public class ProductDbContext : DbContext
{
    public ProductDbContext(DbContextOptions<ProductDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Product>()
            .HasKey(x => x.Id);
    }
}