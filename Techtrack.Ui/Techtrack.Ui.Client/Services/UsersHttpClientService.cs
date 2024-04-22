using System.Net.Http.Json;
using TechTrack.Common.Interfaces.HttpClients;
using TechTrack.Common.ViewModel.Users;

namespace Techtrack.Ui.Client.Services
{
    public class UsersHttpClientService : IUserHttpClientService
    {
        private readonly HttpClient _httpClient;

        public UsersHttpClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<UserWithEquipmentsVm>> GetUsersWithEquipmentsAsync()
        {
            var usersWithEquipments = await _httpClient.GetFromJsonAsync<List<UserWithEquipmentsVm>>("api/users/with-equipments");
            return usersWithEquipments ?? new List<UserWithEquipmentsVm>();
        }
    }
}