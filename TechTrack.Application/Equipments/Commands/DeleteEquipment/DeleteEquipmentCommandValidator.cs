using FluentValidation;

namespace TechTrack.Application.Equipments.Commands.DeleteEquipment
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
