using AutoMapper;
using MediatR;
using System.Linq.Expressions;
using TechTrack.Application.Common.Pagination;
using TechTrack.Application.Constants;
using TechTrack.Application.Equipments.Dtos;
using TechTrack.Application.Equipments.Extensions;
using TechTrack.Application.Equipments.ViewModels;
using TechTrack.Application.Helpers;
using TechTrack.Application.Interfaces.Equipments;
using TechTrack.Domain.Models;
using static TechTrack.Application.Constants.EquipmentSortingConstants;

namespace TechTrack.Application.Equipments.Queries.GetEquipments
{
    public class GetEquipmentsQueryHandler : IRequestHandler<GetEquipmentsQuery, PaginatedResult<EquipmentOutputVm>>
    {
        private readonly IEquipmentReadRepository _equipmentReadRepository;
        private readonly IMapper _mapper;

        public GetEquipmentsQueryHandler(IEquipmentReadRepository equipmentReadRepository, IMapper mapper)
        {
            _equipmentReadRepository = equipmentReadRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<EquipmentOutputVm>> Handle(GetEquipmentsQuery request, CancellationToken cancellationToken)
        {
            var filter = new EquipmentFilterDto(
                request.Filter.PageNumber,
                request.Filter.PageSize)
            {
                SearchFilter = GetFilter(request),
                SortExpression = GetSortingExpression(request.Filter.SortBy),
                SortAscending = request.ShouldSortAscending()
            };

            var paginatedEquipments = await GetEquipments(filter, cancellationToken);

            var equipmentsVm = paginatedEquipments.Data.Select(_mapper.Map<EquipmentOutputVm>)
                .ToList();

            return new PaginatedResult<EquipmentOutputVm>(
                equipmentsVm,
                request.Filter.PageNumber,
                request.Filter.PageSize,
                paginatedEquipments.TotalRecords);
        }

        private async Task<PaginatedResult<EquipmentDto>> GetEquipments(EquipmentFilterDto filter, CancellationToken cancellationToken)
        {
            var paginatedEquipments = await _equipmentReadRepository.FilterEquipmentsAsync(filter, cancellationToken);

            if (paginatedEquipments.TotalRecords <= 0)
            {
                return paginatedEquipments;
            }

            return paginatedEquipments;
        }

        private static Expression<Func<Equipment, bool>> GetFilter(GetEquipmentsQuery filterOn)
        {
            return PredicateBuilder.True<Equipment>()
                .HasGuidEqualTo(filterOn.Filter.Id)
                .AndNameEqualTo(filterOn.Filter.Name)
                .AndTypeEqualTo(filterOn.Filter.Type)
                .AndSerialNumberEqualTo(filterOn.Filter.SerialNumber)
                .AndStatusEqualTo(filterOn.Filter.Status)
                .AndAssignmentDateEqualTo(filterOn.Filter.AssignmentDate)
                .AndReturnDateEqualTo(filterOn.Filter.ReturnDate)
                .AndAssignedToUserIdEqualTo(filterOn.Filter.AssignedToUserId);
        }

        private static Expression<Func<Equipment, object>>? GetSortingExpression(string sortBy)
        {
            var defaultSortBy = SortExpressions[Name];

            if (string.IsNullOrWhiteSpace(sortBy))
            {
                return defaultSortBy;
            }

            if (SortExpressions.ContainsKey(sortBy))
            {
                return SortExpressions[sortBy];
            }

            return SortExpressions.ContainsKey(sortBy)
                ? null
                : defaultSortBy;
        }
    }
}