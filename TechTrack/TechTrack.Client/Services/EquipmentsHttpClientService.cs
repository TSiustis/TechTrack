namespace TechTrack.Blazor.Client.Services;

public class EquipmentsHttpClientService : IEquipmentsHttpClientService
{ 
        private readonly HttpClient _httpClient;

        public EquipmentsHttpClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PaginatedResult<EquipmentOutputVm>> GetEquipmentsAsync(EquipmentInputVm equipmentsFilter)
        {
            return await _httpClient.GetFromJsonAsync<PaginatedResult<EquipmentOutputVm>>($"api/equipments?{equipmentsFilter.ToQueryString()}");
        }

        public async Task<EquipmentDto> GetEquipmentAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<EquipmentDto>($"api/equipment/{id}");
        }

        public async Task CreateEquipmentAsync(EquipmentForCreationDto equipmentDto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/equipments", equipmentDto);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateEquipmentAsync(Guid id, EquipmentForUpdateDto equipmentDto)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/equipments/{id}", equipmentDto);
            response.EnsureSuccessStatusCode();
        }

        public async Task RetireEquipmentAsync(Guid id)
        {
            var response = await _httpClient.PutAsync($"api/equipments/{id}/retire", null);
            response.EnsureSuccessStatusCode();
        }
    }
