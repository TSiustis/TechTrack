using FluentValidation.TestHelper;
using TechTrack.Application.Equipments.Commands.CreateEquipment;
using TechTrack.Common.Dtos.Equipments;

namespace TechTrack.UnitTests.Application.Equipments.Commands.CreateEquipment
{
    public class CreateEquipmentCommandValidatorTests
    {
        private readonly CreateEquipmentCommandValidator _validator;

        public CreateEquipmentCommandValidatorTests()
        {
            _validator = new CreateEquipmentCommandValidator();
        }

        [Fact]
        public void AssignedToUserId_ShouldBeGreaterThanZero()
        {
            // Arrange
            var equipmentForCreationDto = new EquipmentForCreationDto { AssignedToUserId = 0 };
            var model = new CreateEquipmentCommand(equipmentForCreationDto);

            // Act
            var result = _validator.TestValidate(model);
            
            // Assert
            result.ShouldHaveValidationErrorFor("EquipmentForCreationDto.AssignedToUserId");
        }

        [Fact]
        public void ReturnDate_ShouldNotBeEmpty()
        {
            // Arrange
            var equipmentForCreationDto = new EquipmentForCreationDto { ReturnDate = null };
            var model = new CreateEquipmentCommand(equipmentForCreationDto);

            // Act
            var result = _validator.TestValidate(model);
            
            // Assert
            result.ShouldHaveValidationErrorFor("EquipmentForCreationDto.ReturnDate");
        }

        [Fact]
        public void Name_ShouldNotBeEmpty_AndNotExceedMaximumLength()
        {
            // Arrange
            var equipmentForCreationDto = new EquipmentForCreationDto { Name = string.Empty };
            var model = new CreateEquipmentCommand(equipmentForCreationDto);

            // Act
            _validator.TestValidate(model).ShouldHaveValidationErrorFor("EquipmentForCreationDto.Name");

            // Assert
            model.EquipmentForCreationDto.Name = new string('A', 501);
            _validator.TestValidate(model).ShouldHaveValidationErrorFor("EquipmentForCreationDto.Name");
        }

        [Fact]
        public void SerialNumber_ShouldNotBeEmpty_AndNotExceedMaximumLength()
        {
            // Arrange
            var equipmentForCreationDto = new EquipmentForCreationDto { SerialNumber = string.Empty };
            var model = new CreateEquipmentCommand(equipmentForCreationDto);

            // Act
            _validator.TestValidate(model).ShouldHaveValidationErrorFor("EquipmentForCreationDto.SerialNumber");

            // Assert
            model.EquipmentForCreationDto.SerialNumber = new string('A', 25);
            _validator.TestValidate(model).ShouldHaveValidationErrorFor("EquipmentForCreationDto.SerialNumber");
        }

        [Fact]
        public void Type_ShouldNotBeEmpty_AndNotExceedMaximumLength()
        {
            // Arrange
            var equipmentForCreationDto = new EquipmentForCreationDto { Type = string.Empty };
            var model = new CreateEquipmentCommand( equipmentForCreationDto);

            // Act
            _validator.TestValidate(model).ShouldHaveValidationErrorFor("EquipmentForCreationDto.Type");

            // Assert
            model.EquipmentForCreationDto.Type = new string('A', 51); 
            _validator.TestValidate(model).ShouldHaveValidationErrorFor("EquipmentForCreationDto.Type");
        }
    }
}