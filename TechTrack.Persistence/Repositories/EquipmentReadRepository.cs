using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TechTrack.Common.Pagination;
using TechTrack.Common.Dtos.Equipments;
using TechTrack.Application.Interfaces.Equipments;
using TechTrack.Domain.Models;
using TechTrack.Persistence.DatabaseContext;
using System.Linq.Dynamic.Core;
using TechTrack.Domain.Enums;

namespace TechTrack.Persistence.Repositories
{
    public class EquipmentReadRepository : IEquipmentReadRepository
    {
        private readonly ReadDbContext _context;
        private readonly IMapper _mapper;

        public EquipmentReadRepository(ReadDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<EquipmentDto>> FilterEquipmentsAsync(EquipmentFilterDto filter, CancellationToken cancellationToken)
        {
            var searchQuery = _context.Equipments
                .Include(e => e.AssignedTo)
                .AsQueryable()
                .OrderBy(filter.SortExpression)
                .AsNoTracking()
                .Where(filter.SearchFilter);

            var query = _mapper.ProjectTo<EquipmentDto>(searchQuery);

            var totalRecords = await query.CountAsync(cancellationToken);

            if(totalRecords <= 0)
            {
                return new PaginatedResult<EquipmentDto>(
                    new List<EquipmentDto>(),
                    filter.PageNumber,
                    filter.PageSize,
                    totalRecords);
            }

            var equipments = await query
                .AsQueryable()
                .Skip(filter.GetSkipCount())
                .Take(filter.PageSize)
                .ToListAsync(cancellationToken);

            return new PaginatedResult<EquipmentDto>(
                equipments,
                filter.PageNumber,
                filter.PageSize,
                totalRecords);
        }

        public async Task<Equipment> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var equipment = await _context.Equipments.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

            return equipment;
        }

        public void Add(Equipment equipment)
        {
            _context.Equipments.Add(equipment);
        }

        public void Retire(Guid id)
        {
            var equipment = _context.Equipments.Find(id);
            equipment.Status = EquipmentStatus.Retired;
        }

        public void Update(Equipment equipment)
        {
            _context.Equipments.Update(equipment);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
