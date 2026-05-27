using Backend_Api.DTOs;
namespace Backend_Api.Interfaces
{
    public interface IService
    {
        Task<Dto?> GetByIdDTOAsync(int id);
        Task<IEnumerable<Dto>> GetAllDTOsAsync();
        Task<IEnumerable<Dto>> GetDTOsByGyartoAsync(string gyarto);
    }
}