using MediatR;

namespace TechTrack.Application.Equipments.Commands.DeleteEquipment
{
    public class DeleteEquipmentCommand : IRequest
    {
        public DeleteEquipmentCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
