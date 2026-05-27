using AutoMapper;
using Backend_Api.DTOs;
using Backend_Api.Entities;
using Backend_Api.Interfaces;
namespace Backend_Api.Service
{
    public class Service(IRepository repo, IMapper mapper) : IService
    {
        public async Task<IEnumerable<Dto>> GetAllDTOsAsync()
        {
            var entities = await repo.GetAllAsync();
            return mapper.Map<IEnumerable<Dto>>(entities);
        }

        public async Task<Dto?> GetByIdDTOAsync(int id)
        {
            var entity = await repo.GetByIdAsync(id);
            return mapper.Map<Dto>(entity);
        }

        public async Task<IEnumerable<Dto>> GetDTOsByGyartoAsync(string gyarto)
        {
            var entities = await repo.GetByGyartoAsync(gyarto);
            return mapper.Map<IEnumerable<Dto>>(entities);
        }
    }
}