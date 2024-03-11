﻿using FluentValidation;

namespace TechTrack.Application.Equipments.Commands.UpdateEquipment
{
    public class UpdateEquipmentCommandValidator : AbstractValidator<UpdateEquipmentCommand>
    {
        public UpdateEquipmentCommandValidator()
        {
            RuleFor(command => command.Id)
                .NotEmpty();

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