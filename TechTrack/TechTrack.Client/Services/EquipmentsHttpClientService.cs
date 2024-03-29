using Microsoft.AspNetCore.WebUtilities;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using TechTrack.Common.Dtos.Equipments;
using TechTrack.Common.Interfaces.HttpClients;
using TechTrack.Common.Pagination;
using TechTrack.Common.ViewModel.Equipments;

namespace TechTrack.Blazor.Client.Services;

public class EquipmentsHttpClientService : IEquipmentsHttpClientService
{ 
    private readonly HttpClient _httpClient;

    public EquipmentsHttpClientService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public static JsonSerializerOptions GetOptions()
    {
        return new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }

    public async Task<PaginatedResult<EquipmentOutputVm>> GetEquipmentsAsync(EquipmentInputVm equipmentsFilter, JsonSerializerOptions options)
    {
        var queryStringParam = new Dictionary<string, string>
        {
            ["pageNumber"] = equipmentsFilter.PageNumber.ToString(),
            ["pageSize"] = equipmentsFilter .PageSize.ToString()
        };


        if (!string.IsNullOrEmpty(equipmentsFilter.Name))
            queryStringParam.Add("name", equipmentsFilter.Name);

        if (!string.IsNullOrEmpty(equipmentsFilter.Type))
            queryStringParam.Add("type", equipmentsFilter.Type);

        if (!string.IsNullOrEmpty(equipmentsFilter.SerialNumber))
            queryStringParam.Add("serialNumber", equipmentsFilter.SerialNumber);

        if (!string.IsNullOrEmpty(nameof(equipmentsFilter.Status)))
            queryStringParam.Add("status", nameof(equipmentsFilter.Status));

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

        var response = await _httpClient.GetAsync(QueryHelpers.AddQueryString("api/equipments", queryStringParam));
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
