using Backend_Api.DTOs;
using Backend_Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EntityController(IService service) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<Dto>> GetById(int id)
        {
            var tablet = await service.GetByIdDTOAsync(id);
            if (tablet == null)
            {
                return NotFound($"Nem található ezzel az id-val rendelkező rekord: {id} (404)");
            }
            return Ok(tablet);
        }

        [HttpGet]
        public async Task<ActionResult<Dto>> GetAll()
        {
            var tablets = await service.GetAllDTOsAsync();
            if (!tablets.Any())
            {
                return NotFound($"Nincs adat az adatbázisban! (404)");
            }
            return Ok(tablets);
        }

        [HttpGet("gyarto/{gyarto}")]
        public async Task<ActionResult<Dto>> GetAllByGyarto(string gyarto)
        {
            var tablets = await service.GetDTOsByGyartoAsync(gyarto);
            if (!tablets.Any())
            {
                return NotFound($"Nincs ilyen Gyártóval rendelkező rekord az adatbázisban: {gyarto} (404)");
            }
            return Ok(tablets);
        }
    }
}