using AutoMapper;
using TechTrack.Application.Equipments.Dtos;
using TechTrack.Application.Equipments.ViewModels;
using TechTrack.Domain.Models;

namespace TechTrack.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Equipment, EquipmentDto>();
            CreateMap<EquipmentForCreationDto, Equipment>();
            CreateMap<EquipmentForUpdateDto, Equipment>();
            CreateMap<EquipmentDto, EquipmentOutputVm>();
        }
    }
}
