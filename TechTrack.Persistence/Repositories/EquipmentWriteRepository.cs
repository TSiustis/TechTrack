using Microsoft.EntityFrameworkCore;
using TechTrack.Application.Interfaces.Equipments;
using TechTrack.Domain.Models;
using TechTrack.Persistence.DatabaseContext;

namespace TechTrack.Persistence.Repositories
{
    public class EquipmentWriteRepository : IEquipmentWriteRepository
    {
        private readonly WriteDbContext _context;

        public EquipmentWriteRepository(WriteDbContext context)
        {
            _context = context;
        }

        public void Add(Equipment equipment)
        {
            _context.Equipments.Add(equipment);
        }

        public void Delete(Guid id)
        {
            var equipment = _context.Equipments.FirstOrDefault(a => a.Id == id);
            if (equipment != null)
            {
                _context.Equipments.Remove(equipment);
            }
        }

        public Task<Equipment> GetEquipmentAsync(Guid id, CancellationToken cancellationToken)
        {
            var equipment = _context.Equipments.FirstOrDefaultAsync(equipment => equipment.Id == id, cancellationToken);

            return equipment;
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        public void Update(Equipment equipment)
        {
            _context.Equipments.Update(equipment);
        }
    }
}
