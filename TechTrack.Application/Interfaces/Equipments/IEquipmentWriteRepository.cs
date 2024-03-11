using TechTrack.Domain.Models;

namespace TechTrack.Application.Interfaces.Equipments
{
    public interface IEquipmentWriteRepository
    {
        void Add(Equipment equipment);
        void Update(Equipment equipment);
        void Delete(Guid id);
    }
}
