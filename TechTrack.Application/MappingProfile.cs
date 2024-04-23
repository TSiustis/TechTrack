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
            CreateMap<Equipment, EquipmentDto>().ReverseMap();
            CreateMap<EquipmentForCreationDto, Equipment>().ReverseMap();
            CreateMap<EquipmentForUpdateDto, Equipment>().ReverseMap();
            CreateMap<EquipmentDto, EquipmentOutputVm>();
            CreateMap<Equipment, EquipmentDto>()
            .ForMember(dest => dest.AssignedToUserName, opt => opt.MapFrom(src => src.AssignedTo.Name)); ;
        }
    }
}
