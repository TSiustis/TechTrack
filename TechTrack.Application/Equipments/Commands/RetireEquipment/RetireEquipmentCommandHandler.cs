using MediatR;
using TechTrack.Application.Events;
using TechTrack.Application.Interfaces.Equipments;

namespace TechTrack.Application.Equipments.Commands.DeleteEquipment
{
    public class RetireEquipmentCommandHandler : IRequestHandler<RetireEquipmentCommand>
    {
        private readonly IEquipmentWriteRepository _equipmentRepository;

        public RetireEquipmentCommandHandler(IEquipmentWriteRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }

        public async Task Handle(RetireEquipmentCommand request, CancellationToken cancellationToken)
        {
            var equipment = await _equipmentRepository.GetEquipmentAsync(request.Id, cancellationToken);

            if(equipment is null)
            {
                throw new KeyNotFoundException($"Equipment with ID {request.Id} does not exist.");
            }

            equipment.DomainEvents.Add(new EquipmentRetired(equipment.Id));

            _equipmentRepository.Retire(request.Id);

            await _equipmentRepository.SaveChangesAsync(cancellationToken);
        }
    }
}
