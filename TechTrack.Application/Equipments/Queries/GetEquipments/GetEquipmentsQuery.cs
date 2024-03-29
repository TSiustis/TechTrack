using MediatR;
using TechTrack.Common.Pagination;
using TechTrack.Common.ViewModel.Equipments;

namespace TechTrack.Application.Equipments.Queries.GetEquipments
{
    public class GetEquipmentsQuery : IRequest<PaginatedResult<EquipmentOutputVm>>
    {
        public GetEquipmentsQuery(EquipmentInputVm filter)
        {
            Filter = filter;
        }

        public EquipmentInputVm Filter { get; set; }

        public bool ShouldSortAscending()
        {
            var sortDirection = string.IsNullOrWhiteSpace(Filter?.SortDirection)
                ? "asc"
                : Filter.SortDirection;

            return sortDirection.Equals(
                "asc",
                StringComparison.OrdinalIgnoreCase);
        }
    }
}