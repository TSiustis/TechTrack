using MediatR;

namespace TechTrack.Application.Equipment.Commands.DeleteEquipment
{
    public class DeleteEquipmentCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
