﻿using Microsoft.EntityFrameworkCore;
using TechTrack.Application.Equipments.ViewModels;
using TechTrack.Application.Interfaces.Users;
using TechTrack.Application.Users.ViewModels;
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
    }
}