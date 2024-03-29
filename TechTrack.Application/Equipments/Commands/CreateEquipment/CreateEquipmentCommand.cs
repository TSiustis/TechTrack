using MediatR;
using TechTrack.Common.Dtos.Equipments;

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