using Microsoft.EntityFrameworkCore;
using Warehouse.Api.Models; // Importing the models namespace

namespace Warehouse.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // List of database tables
        public DbSet<Product> Products { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WarehouseTask> Tasks { get; set; }
    }
}