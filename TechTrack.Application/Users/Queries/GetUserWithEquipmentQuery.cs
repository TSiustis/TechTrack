using MediatR;
using TechTrack.Common.ViewModel.Users;

namespace TechTrack.Application.Users.Queries;
public class GetUsersWithEquipmentsQuery : IRequest<List<UserWithEquipmentsVm>>
{
}
