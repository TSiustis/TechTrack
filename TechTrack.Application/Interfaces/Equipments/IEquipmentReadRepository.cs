using TechTrack.Application.Common.Pagination;
using TechTrack.Application.Equipments.Dtos;
using TechTrack.Domain.Models;

namespace TechTrack.Application.Interfaces.Equipments
{
    public interface IEquipmentReadRepository
    {
        Task<PaginatedResult<EquipmentDto>> FilterEquipmentsAsync(EquipmentFilterDto filter,
            CancellationToken cancellationToken);
        Task<Equipment> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
