using AutoMapper;
using MediatR;
using TechTrack.Application.Events;
using TechTrack.Application.Interfaces.Equipments;
using TechTrack.Domain.Models;

namespace TechTrack.Application.Equipments.Commands.CreateEquipment
{
    public class CreateEquipmentCommandHandler : IRequestHandler<CreateEquipmentCommand>
    {
        private readonly IEquipmentWriteRepository _equipmentRepository;
        private readonly IMapper _mapper;

        public CreateEquipmentCommandHandler(IEquipmentWriteRepository equipmentRepository, IMapper mapper)
        {
            _equipmentRepository = equipmentRepository;
            _mapper = mapper;
        }

        public async Task Handle(CreateEquipmentCommand request, CancellationToken cancellationToken)
        {
            var equipment = _mapper.Map<Equipment>(request.EquipmentForCreationDto);

            equipment.DomainEvents.Add(new EquipmentCreated(equipment));

            _equipmentRepository.Add(equipment);

            await _equipmentRepository.SaveChangesAsync(cancellationToken);
        }
    }
}
