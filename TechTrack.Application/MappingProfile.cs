using AutoMapper;
using TechTrack.Common.Dtos.Equipments;
using TechTrack.Common.ViewModel.Equipments;
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
