using MediatR;
using TechTrack.Common.Dtos.Users;

namespace TechTrack.Application.Users.Commands;
public class CreateUserCommand : IRequest<Guid>
{
    public UserForCreationDto User { get; set; }    

    public CreateUserCommand(UserForCreationDto user)
    {
        User = user;
    }
}
