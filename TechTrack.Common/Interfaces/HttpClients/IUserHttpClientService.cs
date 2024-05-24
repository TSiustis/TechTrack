using TechTrack.Common.Dtos.Users;
using TechTrack.Common.ViewModel.Users;

namespace TechTrack.Common.Interfaces.HttpClients
{
    public interface IUserHttpClientService
    {
        Task<List<UserWithEquipmentsVm>> GetUsersWithEquipmentsAsync();
        Task AddUserAsync(UserForCreationDto userForCreationDto);
    }
}
