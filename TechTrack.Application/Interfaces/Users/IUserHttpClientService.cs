using TechTrack.Application.Users.ViewModels;

namespace TechTrack.Application.Interfaces.Users;
public interface IUserHttpClientService
{
    Task<List<UserWithEquipmentsVm>> GetUsersWithEquipmentsAsync();
}
