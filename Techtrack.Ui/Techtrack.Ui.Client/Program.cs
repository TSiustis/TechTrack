using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Techtrack.Ui.Client;
using Techtrack.Ui.Client.Services;
using TechTrack.Common.Interfaces.HttpClients;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();

builder.Services.AddScoped<IUserHttpClientService>(sp =>
{
    var httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7212/") };
    return new UsersHttpClientService(httpClient);
});

builder.Services.AddScoped<IEquipmentsHttpClientService>(sp =>
{
    var httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7212/") };
    return new EquipmentsHttpClientService(httpClient);
});

await builder.Build().RunAsync();
