using Backend_Api.Entities;

namespace Backend_Api.Interfaces
{
    public interface IRepository
    {
        Task<Entity?> GetByIdAsync(int id);
        Task<IEnumerable<Entity>> GetAllAsync();
        Task<IEnumerable<Entity>> GetByGyartoAsync(string gyarto);
    }
}