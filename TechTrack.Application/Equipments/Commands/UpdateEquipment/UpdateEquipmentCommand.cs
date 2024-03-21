using MediatR;
using TechTrack.Application.Equipments.Dtos;

namespace TechTrack.Application.Equipments.Commands.UpdateEquipment
{
    public class UpdateEquipmentCommand : IRequest
    {
        public UpdateEquipmentCommand(Guid id, EquipmentForUpdateDto equipment)
        {
            Id = id;
            Equipment = equipment;
        }

        public Guid Id { get; set; }
        public EquipmentForUpdateDto Equipment { get; set; }
    }
}
