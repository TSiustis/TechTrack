using MediatR;
using TechTrack.Domain.Interfaces;

namespace TechTrack.Application.Equipment.Commands.UpdateEquipment
{
    public class UpdateEquipmentCommandHandler : IRequestHandler<UpdateEquipmentCommand>
    {
        private readonly IEquipmentRepository _equipmentRepository;

        public UpdateEquipmentCommandHandler(IEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }

        public Task Handle(UpdateEquipmentCommand request, CancellationToken cancellationToken)
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

            _equipmentRepository.UpdateAsync(equipment);

            return Task.CompletedTask;
        }
    }
}
