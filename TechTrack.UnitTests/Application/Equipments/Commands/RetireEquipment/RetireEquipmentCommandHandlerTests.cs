using FluentAssertions;
using Moq;
using TechTrack.Application.Equipments.Commands.DeleteEquipment;
using TechTrack.Application.Events;
using TechTrack.Application.Interfaces.Equipments;
using TechTrack.Domain.Enums;
using TechTrack.Domain.Models;

namespace TechTrack.UnitTests.Application.Equipments.Commands.RetireEquipment
{
    public class RetireEquipmentCommandHandlerTests
    {
        private readonly Mock<IEquipmentWriteRepository> _mockEquipmentRepository;
        private readonly RetireEquipmentCommandHandler _handler;

        public RetireEquipmentCommandHandlerTests()
        {
            _mockEquipmentRepository = new Mock<IEquipmentWriteRepository>();
            _handler = new RetireEquipmentCommandHandler(_mockEquipmentRepository.Object);
        }

        [Fact]
        public async Task Handle_EquipmentExists_EquipmentRetiredSuccessfully()
        {
            // Arrange
            var equipmentId = Guid.NewGuid();
            var command = new RetireEquipmentCommand(equipmentId);
            var equipment = new Equipment { Id = equipmentId }; // Assuming Equipment has a public constructor

            _mockEquipmentRepository.Setup(repo => repo.GetEquipmentAsync(equipmentId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(equipment);

            _mockEquipmentRepository.Setup(repo => repo.Retire(equipmentId))
                .Verifiable("Equipment was not retired.");

            _mockEquipmentRepository.Setup(repo => repo.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask)
                .Verifiable("Changes were not saved.");

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            _mockEquipmentRepository.Verify();
            equipment.DomainEvents.Should().ContainSingle(e => e is EquipmentRetired);
        }

        [Fact]
        public async Task Handle_EquipmentDoesNotExist_ThrowsKeyNotFoundException()
        {
            // Arrange
            var nonExistentEquipmentId = Guid.NewGuid();
            var command = new RetireEquipmentCommand(nonExistentEquipmentId);

            _mockEquipmentRepository.Setup(repo => repo.GetEquipmentAsync(nonExistentEquipmentId, It.IsAny<CancellationToken>()))
                .ReturnsAsync((Equipment)null);

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() => _handler.Handle(command, CancellationToken.None));
        }

    }
}
