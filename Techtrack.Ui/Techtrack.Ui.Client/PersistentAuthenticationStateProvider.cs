using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using TechTrack.Common.Dtos.Users;
using TechTrack.Common.Interfaces.HttpClients;

namespace Techtrack.Ui.Client;
// This is a client-side AuthenticationStateProvider that determines the user's authentication state by
// looking for data persisted in the page when it was rendered on the server. This authentication state will
// be fixed for the lifetime of the WebAssembly application. So, if the user needs to log in or out, a full
// page reload is required.
//
// This only provides a user name and email for display purposes. It does not actually include any tokens
// that authenticate to the server when making subsequent requests. That works separately using a
// cookie that will be included on HttpClient requests to the server.
internal class PersistentAuthenticationStateProvider : AuthenticationStateProvider
{
    private static readonly Task<AuthenticationState> defaultUnauthenticatedTask =
        Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())));

    private readonly Task<AuthenticationState> authenticationStateTask = defaultUnauthenticatedTask;

    private readonly IUserHttpClientService _clientService;

    public PersistentAuthenticationStateProvider(PersistentComponentState state, IUserHttpClientService clientService)
    {
        _clientService = clientService;

        if (!state.TryTakeFromJson<UserInfo>(nameof(UserInfo), out var userInfo) || userInfo is null)
        {
            return;
        }

        Claim[] claims = [
            new Claim(ClaimTypes.NameIdentifier, userInfo.UserId),
            new Claim(ClaimTypes.Name, userInfo.Name),
            new Claim(ClaimTypes.Email, userInfo.Email)];

        authenticationStateTask = Task.FromResult(
            new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(claims,
                authenticationType: nameof(PersistentAuthenticationStateProvider)))));

        _clientService.AddUserAsync(new UserForCreationDto
        {
            Name = userInfo.Name,
            Email = userInfo.Email,
        });
    }

    public override Task<AuthenticationState> GetAuthenticationStateAsync() => authenticationStateTask;
}
