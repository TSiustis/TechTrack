using MediatR;

namespace TechTrack.Application.Equipments.Commands.DeleteEquipment
{
    public class RetireEquipmentCommand : IRequest
    {
        public RetireEquipmentCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
