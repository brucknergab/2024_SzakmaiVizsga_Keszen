using AutoMapper;
using Backend_Api.Entities;
using Backend_Api.DTOs;

namespace Backend_Api.Helpers
{
   public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Entity, Dto>();
            CreateMap<Dto, Entity>();
        }
    }
}