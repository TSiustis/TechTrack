using TechTrack.Application.Users.ViewModels;

namespace TechTrack.Application.Interfaces.Users
{
    public interface IUsersReadRepository
    {

        Task<List<UserWithEquipmentsVm>> GetUsersWithEquipmentsAsync();
    }
}
