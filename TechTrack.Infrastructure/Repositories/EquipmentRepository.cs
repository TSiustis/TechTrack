using Microsoft.EntityFrameworkCore;
using TechTrack.Domain.Interfaces;
using TechTrack.Domain.Models;
using TechTrack.Infrastructure.Data;

namespace TechTrack.Infrastructure.Repositories
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly TechTrackDbContext _context;

        public EquipmentRepository(TechTrackDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Equipment equipment)
        {
            _context.Equipments.Add(equipment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var equipment = _context.Equipments.FirstOrDefault(a => a.Id == id);
            if (equipment != null)
            {
                _context.Equipments.Remove(equipment);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Equipment>> GetAllAsync()
        {
            return await _context.Equipments.ToListAsync();

        }

        public async Task<Equipment> GetByIdAsync(int id)
        {
            var equipment = await _context.Equipments.FirstOrDefaultAsync(e => e.Id == id);

            return equipment;
        }

        public async Task UpdateAsync(Equipment equipment)
        {
            _context.Equipments.Update(equipment);
            await _context.SaveChangesAsync();
        }
    }
}
