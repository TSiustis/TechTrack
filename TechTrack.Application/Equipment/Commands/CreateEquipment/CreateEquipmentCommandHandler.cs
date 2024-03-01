using MediatR;
using TechTrack.Domain.Models;
using TechTrack.Domain.Interfaces;

namespace TechTrack.Application.Equipment.Commands.CreateEquipment
{
    public class CreateEquipmentCommandHandler : IRequestHandler<CreateEquipmentCommand>
    {
        private readonly IEquipmentRepository _equipmentRepository;

        public CreateEquipmentCommandHandler(IEquipmentRepository equipmentRepository)
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

            _equipmentRepository.AddAsync(equipment);

            return Task.CompletedTask;
        }
    }
}
