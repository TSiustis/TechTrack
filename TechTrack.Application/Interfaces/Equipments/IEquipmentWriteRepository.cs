using TechTrack.Domain.Models;

namespace TechTrack.Application.Interfaces.Equipments
{
    public interface IEquipmentWriteRepository
    {   
        Task<Equipment> GetEquipmentAsync(Guid id, CancellationToken cancellationToken);
        void Add(Equipment equipment);
        void Update(Equipment equipment);
        void Delete(Guid id);
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
