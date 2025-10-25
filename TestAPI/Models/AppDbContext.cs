using Microsoft.EntityFrameworkCore;
using TestAPI.Models;

namespace TestApI.Models

{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Department> departments { get; set; }

    }
}
