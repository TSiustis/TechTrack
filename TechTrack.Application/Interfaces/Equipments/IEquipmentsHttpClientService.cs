using TechTrack.Application.Common.Pagination;
using TechTrack.Application.Equipments.Dtos;
using TechTrack.Application.Equipments.ViewModels;

namespace TechTrack.Application.Interfaces.Equipments
{
    public interface IEquipmentsHttpClientService
    {
        Task<PaginatedResult<EquipmentOutputVm>> GetEquipmentsAsync(EquipmentInputVm equipmentsFilter);
        Task<EquipmentDto> GetEquipmentAsync(Guid id);
        Task CreateEquipmentAsync(EquipmentForCreationDto equipmentDto);
        Task UpdateEquipmentAsync(Guid id, EquipmentForUpdateDto equipmentDto);
        Task RetireEquipmentAsync(Guid id);
    }
}