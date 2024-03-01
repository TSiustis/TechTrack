using TechTrack.Application.Dtos.Equipment;

namespace TechTrack.Application.Interfaces
{
    public interface IEquipmentService
    {
        Task<IEnumerable<EquipmentDto>> GetAllEquipmentsAsync();
        Task<EquipmentDto> GetEquipmentByIdAsync(int id);
        Task<EquipmentDto> CreateEquipmentAsync(EquipmentForCreationDto equipmentDto);
        Task UpdateEquipmentAsync(int id, EquipmentForUpdateDto equipmentDto);
        Task DeleteEquipmentAsync(int id);
    }
}
