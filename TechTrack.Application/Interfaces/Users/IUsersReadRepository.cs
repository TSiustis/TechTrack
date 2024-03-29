﻿using TechTrack.Common.ViewModel.Users;

namespace TechTrack.Application.Interfaces.Users
{
    public interface IUsersReadRepository
    {

        Task<List<UserWithEquipmentsVm>> GetUsersWithEquipmentsAsync();
    }
}
