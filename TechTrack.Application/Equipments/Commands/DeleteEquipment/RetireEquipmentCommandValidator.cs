using FluentValidation;

namespace TechTrack.Application.Equipments.Commands.DeleteEquipment
{
    public class RetireEquipmentCommandValidator : AbstractValidator<RetireEquipmentCommand>
    {
        public RetireEquipmentCommandValidator()
        {
            RuleFor(command => command.Id)
                .NotNull()
                .NotEmpty();
        }
    }
}
