using AutoMapper;
using Moq;
using TechTrack.Application.Equipments.Commands.UpdateEquipment;
using TechTrack.Common.Dtos.Equipments;
using TechTrack.Application.Interfaces.Equipments;
using TechTrack.Domain.Models;

namespace TechTrack.UnitTests.Application.Equipments.Commands.UpdateEquipment
{
    public class UpdateEquipmentCommandHandlerTests
    {
        private readonly Mock<IEquipmentWriteRepository> _mockEquipmentRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly UpdateEquipmentCommandHandler _handler;

        public UpdateEquipmentCommandHandlerTests()
        {
            _mockEquipmentRepository = new Mock<IEquipmentWriteRepository>();
            _mockMapper = new Mock<IMapper>();
            _handler = new UpdateEquipmentCommandHandler(_mockEquipmentRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task Handle_ValidCommand_UpdatesEquipment()
        {
            // Arrange
            var equipmentId = Guid.NewGuid();
            var equipmentDto = new EquipmentForUpdateDto();
            var equipment = new Equipment(); 

            _mockEquipmentRepository.Setup(repo => repo.GetEquipmentAsync(equipmentId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(equipment);

            var command = new UpdateEquipmentCommand(equipmentId, equipmentDto);

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            _mockMapper.Verify(mapper => mapper.Map(equipmentDto, equipment), Times.Once);
            _mockEquipmentRepository.Verify(repo => repo.Update(equipment), Times.Once);
            _mockEquipmentRepository.Verify(repo => repo.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Handle_InvalidEquipmentId_ThrowsKeyNotFoundException()
        {
            // Arrange
            var equipmentId = Guid.NewGuid();
            var equipmentDto = new EquipmentForUpdateDto(); 
            _mockEquipmentRepository.Setup(repo => repo.GetEquipmentAsync(equipmentId, It.IsAny<CancellationToken>()))
                .ReturnsAsync((Equipment)null);

            var command = new UpdateEquipmentCommand(equipmentId, equipmentDto);

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() => _handler.Handle(command, CancellationToken.None));
        }
    }
}