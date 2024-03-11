using MediatR;
using TechTrack.Application.Interfaces.Equipments;

namespace TechTrack.Application.Equipments.Commands.CreateEquipment
{
    public class CreateEquipmentCommandHandler : IRequestHandler<CreateEquipmentCommand>
    {
        private readonly IEquipmentWriteRepository _equipmentRepository;

        public CreateEquipmentCommandHandler(IEquipmentWriteRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }

        public Task Handle(CreateEquipmentCommand request, CancellationToken cancellationToken)
        {
            var equipment = new TechTrack.Domain.Models.Equipment
            {
                Name = request.Name,
                SerialNumber = request.SerialNumber,
                AssignmentDate = DateTime.UtcNow,
                Type = request.Type,
                Status = request.Status,
                AssignedToUserId = request.AssignedToUserId,
            };

            _equipmentRepository.Add(equipment);

            return Task.CompletedTask;
        }
    }
}
