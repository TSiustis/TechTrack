using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Techtrack.Ui.Client;
using Techtrack.Ui.Client.Services;
using TechTrack.Common.Interfaces.HttpClients;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();
builder.Services.AddScoped<IUserHttpClientService, UsersHttpClientService>();
builder.Services.AddScoped<IEquipmentsHttpClientService, EquipmentsHttpClientService>();


await builder.Build().RunAsync();
