using AutoMapper;
using MediatR;
using TechTrack.Application.Events;
using TechTrack.Application.Interfaces.Equipments;
using TechTrack.Domain.Models;

namespace TechTrack.Application.Equipments.Commands.UpdateEquipment
{
    public class UpdateEquipmentCommandHandler : IRequestHandler<UpdateEquipmentCommand>
    {
        private readonly IEquipmentWriteRepository _equipmentRepository;
        private readonly IMapper _mapper; 

        public UpdateEquipmentCommandHandler(IEquipmentWriteRepository equipmentRepository, IMapper mapper)
        {
            _equipmentRepository = equipmentRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateEquipmentCommand request, CancellationToken cancellationToken)
        {

            var equipment = await _equipmentRepository.GetEquipmentAsync(request.Id, cancellationToken);

            if (equipment is null)
            {
                throw new KeyNotFoundException($"Equipment with id {request.Id} does not exist.");
            }

            _mapper.Map(request.Equipment, equipment);

            equipment.DomainEvents.Add(new EquipmentUpdated(equipment));

            _equipmentRepository.Update(equipment);

            await _equipmentRepository.SaveChangesAsync(cancellationToken);
        }
    }
}
