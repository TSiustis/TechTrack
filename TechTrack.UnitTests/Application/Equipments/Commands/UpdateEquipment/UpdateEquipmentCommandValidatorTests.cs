using FluentValidation.TestHelper;
using Moq;
using TechTrack.Application.Equipments.Commands.UpdateEquipment;
using TechTrack.Application.Equipments.Dtos;
using TechTrack.Application.Interfaces.Equipments;
using TechTrack.Domain.Models;

namespace TechTrack.Application.Tests.Equipments.Commands.UpdateEquipment
{
    public class UpdateEquipmentCommandValidatorTests
    {
        private readonly UpdateEquipmentCommandValidator _validator;
        private readonly Mock<IEquipmentReadRepository> _mockEquipmentReadRepository;

        public UpdateEquipmentCommandValidatorTests()
        {
            _mockEquipmentReadRepository = new Mock<IEquipmentReadRepository>();
            _validator = new UpdateEquipmentCommandValidator(_mockEquipmentReadRepository.Object);
        }

        [Fact]
        public async Task Equipment_ShouldExist()
        {
            // Arrange
            var equipmentId = Guid.NewGuid();
            _mockEquipmentReadRepository.Setup(x => x.GetByIdAsync(equipmentId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Equipment()); 

            var command = new UpdateEquipmentCommand(equipmentId, new EquipmentForUpdateDto());

            // Act
            var result = await _validator.TestValidateAsync(command);

            // Assert
            result.ShouldNotHaveValidationErrorFor(c => c.Id);
        }

        [Fact]
        public async Task Equipment_ShouldNotExist()
        {
            // Arrange
            var nonExistentEquipmentId = Guid.NewGuid();
            _mockEquipmentReadRepository.Setup(x => x.GetByIdAsync(nonExistentEquipmentId, It.IsAny<CancellationToken>()))
                .ReturnsAsync((Equipment)null); // Simulate that equipment does not exist

            var command = new UpdateEquipmentCommand(nonExistentEquipmentId, new EquipmentForUpdateDto());

            // Act
            var result = await _validator.TestValidateAsync(command);

            // Assert
            result.ShouldHaveValidationErrorFor(c => c.Id).WithErrorMessage($"Equipment with ID {nonExistentEquipmentId} does not exist.");
        }



    }
}
