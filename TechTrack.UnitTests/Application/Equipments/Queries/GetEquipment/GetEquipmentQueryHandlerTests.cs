using AutoFixture;
using AutoMapper;
using FluentAssertions;
using Moq;
using TechTrack.Application;
using TechTrack.Common.Dtos.Equipments;
using TechTrack.Application.Equipments.Queries.GetEquipment;
using TechTrack.Application.Interfaces.Equipments;
using TechTrack.Domain.Models;

namespace TechTrack.UnitTests.Application.Equipments.Queries.GetEquipment
{
    public class GetEquipmentQueryHandlerTests
    {
        private readonly Mock<IEquipmentReadRepository> _mockEquipmentRepository;
        private readonly IMapper _mapper;
        private readonly GetEquipmentQueryHandler _handler;

        public GetEquipmentQueryHandlerTests()
        {
            _mockEquipmentRepository = new Mock<IEquipmentReadRepository>();
            // Setup AutoMapper
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configuration.CreateMapper();
            _handler = new GetEquipmentQueryHandler(_mockEquipmentRepository.Object, _mapper);
        }

        [Fact]
        public async Task Handle_ValidId_ReturnsMappedEquipmentDto()
        {
            // Arrange
            var equipmentId = Guid.NewGuid();
            var equipment = new Equipment { Id = equipmentId, Name = "Test Equipment" }; 

            _mockEquipmentRepository.Setup(repo => repo.GetByIdAsync(equipmentId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(equipment);

            var query = new GetEquipmentQuery(equipmentId);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(equipmentId);
            result.Name.Should().Be("Test Equipment");
            _mockEquipmentRepository.Verify(repo => repo.GetByIdAsync(equipmentId, It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Handle_InvalidId_ReturnsNull()
        {
            // Arrange
            var invalidEquipmentId = Guid.NewGuid();

            _mockEquipmentRepository.Setup(repo => repo.GetByIdAsync(invalidEquipmentId, It.IsAny<CancellationToken>()))
                .ReturnsAsync((Equipment)null);

            var query = new GetEquipmentQuery(invalidEquipmentId);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            result.Should().BeNull();
        }

    }

}