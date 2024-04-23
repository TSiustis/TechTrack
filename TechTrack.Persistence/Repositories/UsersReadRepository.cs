using Microsoft.EntityFrameworkCore;
using TechTrack.Common.ViewModel.Equipments;
using TechTrack.Application.Interfaces.Users;
using TechTrack.Common.ViewModel.Users;
using TechTrack.Domain.Models;
using TechTrack.Persistence.DatabaseContext;

namespace TechTrack.Persistence.Repositories
{
    public class UsersReadRepository : IUsersReadRepository
    {
        private readonly ReadDbContext _context;

        public UsersReadRepository(ReadDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserWithEquipmentsVm>> GetUsersWithEquipmentsAsync()
        {
            var usersWithEquipments = await _context.Users
                .Select(u => new UserWithEquipmentsVm
                {
                    UserId = u.Id,
                    Name = u.Name,
                    Email = u.Email,
                    Department = u.Department,
                    Equipments = u.AssignedEquipments.Select(eq => new EquipmentOutputVm
                    {
                        Id = eq.Id,
                        Name = eq.Name,
                        Type = eq.Type,
                        SerialNumber = eq.SerialNumber,
                        Status = eq.Status,
                        AssignmentDate = eq.AssignmentDate,
                        ReturnDate = eq.ReturnDate
                    }).ToList()
                }).ToListAsync();

            return usersWithEquipments;
        }
        public async Task<string> GetAssignedUserName(Guid assignedToUserId)
        {
            var user = await _context.Users.FindAsync(assignedToUserId);
            return user?.Name;
        }
    }
}