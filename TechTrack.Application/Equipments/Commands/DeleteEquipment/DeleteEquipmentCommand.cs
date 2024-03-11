using MediatR;

namespace TechTrack.Application.Equipments.Commands.DeleteEquipment
{
    public class DeleteEquipmentCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
