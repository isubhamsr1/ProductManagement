using Microsoft.EntityFrameworkCore;
using ProductManagement.API.Models;

namespace ProductManagement.API.Data
{
    public class AppicationDbContext : DbContext
    {
        public AppicationDbContext(DbContextOptions<AppicationDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
