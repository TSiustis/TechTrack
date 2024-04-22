using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using TechTrack.Common.Dtos.Equipments;
using TechTrack.Common.Interfaces.HttpClients;
using TechTrack.Common.Pagination;
using TechTrack.Common.ViewModel.Equipments;
using TechTrack.Domain.Enums;

namespace Techtrack.Ui.Client.Services
{

    public class EquipmentsHttpClientService : IEquipmentsHttpClientService
    {
        private readonly HttpClient _httpClient;

        public EquipmentsHttpClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PaginatedResult<EquipmentOutputVm>> GetEquipmentsAsync(EquipmentInputVm equipmentsFilter)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["pageNumber"] = equipmentsFilter.PageNumber.ToString(),
                ["pageSize"] = equipmentsFilter.PageSize.ToString()
            };

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            options.Converters.Add(new JsonStringEnumConverter());

            if (!string.IsNullOrEmpty(equipmentsFilter.Name))
                queryStringParam.Add("name", equipmentsFilter.Name);

            if (!string.IsNullOrEmpty(equipmentsFilter.Type))
                queryStringParam.Add("type", equipmentsFilter.Type);

            if (!string.IsNullOrEmpty(equipmentsFilter.SerialNumber))
                queryStringParam.Add("serialNumber", equipmentsFilter.SerialNumber);

            if (equipmentsFilter.Status != null)
                queryStringParam.Add("status", Enum.GetName(typeof(EquipmentStatus), ((int)equipmentsFilter.Status)));

            if (!string.IsNullOrEmpty(equipmentsFilter.AssignmentDate.ToString()))
                queryStringParam.Add("assignmentDate", equipmentsFilter.AssignmentDate.ToString());

            if (!string.IsNullOrEmpty(equipmentsFilter.ReturnDate.ToString()))
                queryStringParam.Add("returnDate", equipmentsFilter.ReturnDate.ToString());


            if (!string.IsNullOrEmpty(equipmentsFilter.AssignedToUserId.ToString()))
                queryStringParam.Add("assignedToUserId", equipmentsFilter.AssignedToUserId.ToString());

            if (!string.IsNullOrEmpty(equipmentsFilter.SortBy))
                queryStringParam.Add("sortBy", equipmentsFilter.SortBy);

            if (!string.IsNullOrEmpty(equipmentsFilter.SortDirection))
                queryStringParam.Add("sortDirection", equipmentsFilter.SortDirection);

            var response = await _httpClient.GetAsync(QueryHelpers.AddQueryString("api/v1/equipments", queryStringParam));
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var items = JsonSerializer.Deserialize<PaginatedResult<EquipmentOutputVm>>(content, options);

            return items;
        }

        public async Task<EquipmentDto> GetEquipmentAsync(Guid id)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            options.Converters.Add(new JsonStringEnumConverter());

            var response = await _httpClient.GetAsync($"api/v1/equipment/{id}");

            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var equipment = JsonSerializer.Deserialize<EquipmentDto>(content, options);

            return equipment;
        }

        public async Task CreateEquipmentAsync(EquipmentForCreationDto equipmentDto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/v1/equipments", equipmentDto);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateEquipmentAsync(Guid id, EquipmentForUpdateDto equipmentDto)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/v1/equipments/{id}", equipmentDto);
            response.EnsureSuccessStatusCode();
        }

        public async Task RetireEquipmentAsync(Guid id)
        {
            var response = await _httpClient.PutAsync($"api/v1/equipments/{id}/retire", null);
            response.EnsureSuccessStatusCode();
        }
    }

}
