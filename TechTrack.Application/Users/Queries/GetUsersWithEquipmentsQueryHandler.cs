using MediatR;
using TechTrack.Application.Interfaces.Users;
using TechTrack.Application.Users.ViewModels;

namespace TechTrack.Application.Users.Queries;

public class GetUsersWithEquipmentsQueryHandler : IRequestHandler<GetUsersWithEquipmentsQuery, List<UserWithEquipmentsVm>>
{
    private readonly IUsersReadRepository _userReadRepository;

    public GetUsersWithEquipmentsQueryHandler(IUsersReadRepository userReadRepository)
    {
        _userReadRepository = userReadRepository;
    }

    public async Task<List<UserWithEquipmentsVm>> Handle(GetUsersWithEquipmentsQuery request, CancellationToken cancellationToken)
    {
        return await _userReadRepository.GetUsersWithEquipmentsAsync();
    }
}
