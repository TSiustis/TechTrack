using TechTrack.Common.ViewModel.Users;

namespace TechTrack.Application.Interfaces.Users;
public interface IUserHttpClientService
{
    Task<List<UserWithEquipmentsVm>> GetUsersWithEquipmentsAsync();
}
