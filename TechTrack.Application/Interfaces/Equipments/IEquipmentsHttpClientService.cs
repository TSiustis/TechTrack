﻿using TechTrack.Common.Pagination;
using TechTrack.Common.Dtos.Equipments;
using TechTrack.Common.ViewModel.Equipments;

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