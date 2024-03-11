using MediatR;
using TechTrack.Application.Interfaces.Equipments;

namespace TechTrack.Application.Equipments.Commands.UpdateEquipment
{
    public class UpdateEquipmentCommandHandler : IRequestHandler<UpdateEquipmentCommand>
    {
        private readonly IEquipmentWriteRepository _equipmentRepository;

        public UpdateEquipmentCommandHandler(IEquipmentWriteRepository equipmentRepository)
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

            _equipmentRepository.Update(equipment);

            return Task.CompletedTask;
        }
    }
}
