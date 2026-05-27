using Backend_Api.Entities;
using Backend_Api.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace Backend_Api.Data
{
    public class Repository(AppDbContext context) : IRepository
    {
        public async Task<IEnumerable<Entity>> GetAllAsync()
        {
            return await context.Tabletek.ToListAsync();
        }

        public async Task<IEnumerable<Entity>> GetByGyartoAsync(string gyarto)
        {
            return await context.Tabletek.Where(t => t.Gyarto == gyarto).ToListAsync();
        }

        public async Task<Entity?> GetByIdAsync(int id)
        {
            return await context.Tabletek.Where(t => t.Id == id).FirstOrDefaultAsync();
        }
    }
}