using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;

namespace WebApplication4.Contexts;

public class DatabaseContext : DbContext
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Status> Status { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product_Order> Product_Order { get; set; }
    
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product_Order>()
            .HasKey(po => new { po.ProductID, po.OrderID });
    }
}