using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TechTrack.Blazor.Client.Services;
using TechTrack.Blazor.Client;
using TechTrack.Common.Interfaces.HttpClients;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>(); builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IUserHttpClientService, UserHttpClientService>();
builder.Services.AddScoped<IEquipmentsHttpClientService, EquipmentsHttpClientService>();


await builder.Build().RunAsync();
