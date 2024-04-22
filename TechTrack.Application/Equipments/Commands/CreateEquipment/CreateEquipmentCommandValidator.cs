using FluentValidation;

namespace TechTrack.Application.Equipments.Commands.CreateEquipment
{
    public class CreateEquipmentCommandValidator : AbstractValidator<CreateEquipmentCommand>
    {
        public CreateEquipmentCommandValidator()
        {
            RuleFor(command => command.EquipmentForCreationDto.
            AssignedToUserId)
                .NotNull();

            RuleFor(command => command.EquipmentForCreationDto.
            ReturnDate)
                .NotEmpty();

            RuleFor(command => command.EquipmentForCreationDto.
            Name)
                .NotEmpty()
                .MaximumLength(500);

            RuleFor(command => command.EquipmentForCreationDto.
            SerialNumber)
                .NotEmpty()
                .MaximumLength(24);

            RuleFor(command => command.EquipmentForCreationDto.
            Type)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
