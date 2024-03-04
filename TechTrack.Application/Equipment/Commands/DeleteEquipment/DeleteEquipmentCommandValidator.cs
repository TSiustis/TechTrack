using FluentValidation;

namespace TechTrack.Application.Equipment.Commands.DeleteEquipment
{
    public class DeleteEquipmentCommandValidator : AbstractValidator<DeleteEquipmentCommand>
    {
        public DeleteEquipmentCommandValidator()
        {
            RuleFor(command => command.Id)
                .NotNull()
                .NotEmpty();
        }
    }
}
