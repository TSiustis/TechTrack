using FluentValidation;
using TechTrack.Application.Interfaces.Equipments;

namespace TechTrack.Application.Equipments.Commands.UpdateEquipment
{
    public class UpdateEquipmentCommandValidator : AbstractValidator<UpdateEquipmentCommand>
    {
        private readonly IEquipmentReadRepository _equipmentReadRepository;

        
        public UpdateEquipmentCommandValidator(IEquipmentReadRepository equipmentReadRepository)
        {
            _equipmentReadRepository = equipmentReadRepository;

            RuleFor(command => command.Id)
                .NotEmpty()
                .MustAsync(EquipmentExists)
                .WithMessage(command => $"Equipment with ID {command.Id} does not exist.");
        }

        private async Task<bool> EquipmentExists(Guid id, CancellationToken cancellationToken)
        {
            var equipment = await _equipmentReadRepository.GetByIdAsync(id, cancellationToken);

            return equipment is not null;
        }
    }
}
