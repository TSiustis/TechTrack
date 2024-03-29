using MediatR;
using TechTrack.Common.Dtos.Equipments;

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
