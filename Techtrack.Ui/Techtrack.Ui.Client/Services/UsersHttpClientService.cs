using Microsoft.AspNetCore.WebUtilities;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using TechTrack.Common.Dtos.Equipments;
using TechTrack.Common.Dtos.Users;
using TechTrack.Common.Interfaces.HttpClients;
using TechTrack.Common.Pagination;
using TechTrack.Common.ViewModel.Equipments;
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

        public async Task AddUserAsync(UserForCreationDto userForCreationDto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/v1/users", userForCreationDto);
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<UserWithEquipmentsVm>> GetUsersWithEquipmentsAsync()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            options.Converters.Add(new JsonStringEnumConverter());

            var response = await _httpClient.GetAsync("api/v1/users/with-equipments");
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var users = JsonSerializer.Deserialize<List<UserWithEquipmentsVm>>(content, options);

            return users ?? [];
        }
    }
}