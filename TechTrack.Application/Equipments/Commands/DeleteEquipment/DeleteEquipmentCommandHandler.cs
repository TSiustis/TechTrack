using MediatR;
using TechTrack.Application.Interfaces.Equipments;

namespace TechTrack.Application.Equipments.Commands.DeleteEquipment
{
    public class DeleteEquipmentCommandHandler : IRequestHandler<DeleteEquipmentCommand>
    {
        private readonly IEquipmentWriteRepository _equipmentRepository;

        public DeleteEquipmentCommandHandler(IEquipmentWriteRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }

        public Task Handle(DeleteEquipmentCommand request, CancellationToken cancellationToken)
        {
            _equipmentRepository.Delete(request.Id);

            return Task.CompletedTask;
        }
    }
}
