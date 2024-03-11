using Microsoft.EntityFrameworkCore;
using TechTrack.Application.Interfaces.Equipments;
using TechTrack.Domain.Models;
using TechTrack.Persistence.DatabaseContext;

namespace TechTrack.Persistence.Repositories
{
    public class EquipmentReadRepository : IEquipmentReadRepository
    {
        private readonly ReadDbContext _context;

        public EquipmentReadRepository(ReadDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Equipment>> GetAllAsync()
        {
            return await _context.Equipments.ToListAsync();

        }

        public async Task<Equipment> GetByIdAsync(Guid id)
        {
            var equipment = await _context.Equipments.FirstOrDefaultAsync(e => e.Id == id);

            return equipment;
        }
    }
}
