namespace TechTrack.Blazor.Client.Services
{
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TechTrack.Application.Users.ViewModels;

    public class UsersHttpClientService
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