using AutoFixture;
using AutoMapper;
using FluentAssertions;
using Moq;
using TechTrack.Application;
using TechTrack.Common.Pagination;
using TechTrack.Common.Dtos.Equipments;
using TechTrack.Application.Equipments.Queries.GetEquipments;
using TechTrack.Common.ViewModel.Equipments;
using TechTrack.Application.Interfaces.Equipments;

namespace TechTrack.UnitTests.Application.Equipments.Queries.GetEquipments
{
    public class GetEquipmentsQueryHandlerTests
    {
        private readonly Mock<IEquipmentReadRepository> _mockEquipmentReadRepository;
        private readonly IMapper _mapper;
        private readonly GetEquipmentsQueryHandler _handler;
        private readonly Fixture _fixture = new();

        public GetEquipmentsQueryHandlerTests()
        {
            _mockEquipmentReadRepository = new Mock<IEquipmentReadRepository>();
            // Setup AutoMapper
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configuration.CreateMapper();
            _handler = new GetEquipmentsQueryHandler(_mockEquipmentReadRepository.Object, _mapper);
        }

        [Fact]
        public async Task Handle_ValidFilter_ReturnsPaginatedResult()
        {
            // Arrange
            const int pageNumber = 1;
            const int pageSize = 10;

            var equipmentInputVm = new EquipmentInputVm
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            var data = _fixture.CreateMany<EquipmentDto>()
                .ToList();

            var request = new GetEquipmentsQuery(equipmentInputVm);   

            var paginatedResult = new PaginatedResult<EquipmentDto>(data, 1, 10, 100);
            _mockEquipmentReadRepository.Setup(repo => repo.FilterEquipmentsAsync(It.IsAny<EquipmentFilterDto>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(paginatedResult);

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Data.Should().NotBeEmpty();
            result.PageNumber.Should().Be(1);
            result.PageSize.Should().Be(10);
            result.TotalRecords.Should().Be(100);
        }

        [Fact]
        public async Task Handle_NoEquipmentsFound_ReturnsEmptyPaginatedResult()
        {
            // Arrange
            var request = new GetEquipmentsQuery(new EquipmentInputVm()); 

            var paginatedResult = new PaginatedResult<EquipmentDto>(new List<EquipmentDto>(), 1, 10, 0);
            _mockEquipmentReadRepository.Setup(repo => repo.FilterEquipmentsAsync(It.IsAny<EquipmentFilterDto>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(paginatedResult);

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Data.Should().BeEmpty();
            result.TotalRecords.Should().Be(0);
        }

    }
}