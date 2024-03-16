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

        public async Task Handle(DeleteEquipmentCommand request, CancellationToken cancellationToken)
        {
            var equipment = await _equipmentRepository.GetEquipmentAsync(request.Id, cancellationToken);

            if(equipment is null)
            {
                throw new KeyNotFoundException($"Equipment with ID {request.Id} does not exist.");
            }

            _equipmentRepository.Delete(request.Id);

            await _equipmentRepository.SaveChangesAsync(cancellationToken);
        }
    }
}
