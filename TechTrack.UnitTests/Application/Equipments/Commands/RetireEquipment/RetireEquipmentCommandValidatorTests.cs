using FluentValidation.TestHelper;
using TechTrack.Application.Equipments.Commands.DeleteEquipment;
using Xunit;

namespace TechTrack.Application.Tests.Equipments.Commands.RetireEquipment
{
    public class RetireEquipmentCommandValidatorTests
    {
        private readonly RetireEquipmentCommandValidator _validator;

        public RetireEquipmentCommandValidatorTests()
        {
            _validator = new RetireEquipmentCommandValidator();
        }

        [Fact]
        public void RetireEquipmentCommandValidator_WithEmptyId_ShouldHaveValidationError()
        {
            // Arrange
            var command = new RetireEquipmentCommand (Guid.Empty);

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(command => command.Id);
        }

        [Fact]
        public void RetireEquipmentCommandValidator_WithValidId_ShouldNotHaveValidationError()
        {
            // Arrange
            var command = new RetireEquipmentCommand (Guid.NewGuid());

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldNotHaveValidationErrorFor(command => command.Id);
        }

    }
}
