using Microsoft.EntityFrameworkCore;
using Backend_Api.Entities;


namespace Backend_Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Entity> Tabletek { get; set; }
    }

}