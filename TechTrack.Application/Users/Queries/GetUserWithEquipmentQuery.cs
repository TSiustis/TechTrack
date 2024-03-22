using MediatR;
using TechTrack.Application.Users.ViewModels;

namespace TechTrack.Application.Users.Queries;
public class GetUsersWithEquipmentsQuery : IRequest<List<UserWithEquipmentsVm>>
{
}
