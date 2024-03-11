using FluentValidation;

namespace TechTrack.Application.Equipments.Commands.CreateEquipment
{
    public class CreateEquipmentCommandValidator : AbstractValidator<CreateEquipmentCommand>
    {
        public CreateEquipmentCommandValidator()
        {
            RuleFor(command => command.AssignedToUserId)
                .GreaterThan(0);

            RuleFor(command => command.ReturnDate)
                .NotEmpty();

            RuleFor(command => command.Name)
                .NotEmpty()
                .MaximumLength(500);

            RuleFor(command => command.SerialNumber)
                .NotEmpty()
                .MaximumLength(24);

            RuleFor(command => command.Type)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
