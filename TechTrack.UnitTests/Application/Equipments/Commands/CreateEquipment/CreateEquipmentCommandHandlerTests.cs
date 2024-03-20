using AutoFixture;
using AutoMapper;
using Moq;
using TechTrack.Application;
using TechTrack.Application.Equipments.Commands.CreateEquipment;
using TechTrack.Application.Equipments.Dtos;
using TechTrack.Application.Events;
using TechTrack.Application.Interfaces.Equipments;
using TechTrack.Domain.Models;

namespace TechTrack.UnitTests.Application.Equipments.Commands.CreateEquipment
{
    public class CreateEquipmentCommandHandlerTests
    {
        private readonly Mock<IEquipmentWriteRepository> _mockEquipmentRepository;
        private readonly IMapper _mapper;
        private readonly CreateEquipmentCommandHandler _handler;

        public CreateEquipmentCommandHandlerTests()
        {
            _mockEquipmentRepository = new Mock<IEquipmentWriteRepository>();

            // Setup AutoMapper
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>(); 
            });
            _mapper = configuration.CreateMapper();

            _handler = new CreateEquipmentCommandHandler(_mockEquipmentRepository.Object, _mapper);
        }

        [Fact]
        public async Task Handle_ValidRequest_AddsEquipmentToRepository()
        {
            // Arrange
            var fixture = new Fixture();
            var equipmentForCreationDto = fixture.Create<EquipmentForCreationDto>();
            var request = new CreateEquipmentCommand (equipmentForCreationDto);

            _mockEquipmentRepository.Setup(repo => repo.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            // Act
            await _handler.Handle(request, CancellationToken.None);

            // Assert
            _mockEquipmentRepository.Verify(repo => repo.Add(It.IsAny<Equipment>()), Times.Once);
            _mockEquipmentRepository.Verify(repo => repo.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Handle_ValidRequest_TriggerEquipmentCreatedDomainEvent()
        {
            // Arrange
            var fixture = new Fixture();
            var equipmentDto = fixture.Create<EquipmentForCreationDto>();
            var request = new CreateEquipmentCommand (equipmentDto);

            Equipment capturedEquipment = null;
            _mockEquipmentRepository.Setup(repo => repo.Add(It.IsAny<Equipment>()))
                .Callback<Equipment>(equipment => capturedEquipment = equipment);

            // Act
            await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(capturedEquipment);
            Assert.Contains(capturedEquipment.DomainEvents, e => e is EquipmentCreated);
        }


    }
}