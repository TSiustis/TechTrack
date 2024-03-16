using MediatR;
using TechTrack.Application.Equipments.Dtos;

namespace TechTrack.Application.Equipments.Commands.CreateEquipment
{
    public class CreateEquipmentCommand : IRequest
    {
        public CreateEquipmentCommand(EquipmentForCreationDto equipmentForCreationDto)
        {
            EquipmentForCreationDto = equipmentForCreationDto;
        }

        public EquipmentForCreationDto EquipmentForCreationDto { get; }
    }
}