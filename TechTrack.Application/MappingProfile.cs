using AutoMapper;
using TechTrack.Application.Dtos.Equipment;
using TechTrack.Domain.Models;

namespace TechTrack.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Equipment, EquipmentDto>();
        }
    }
}
