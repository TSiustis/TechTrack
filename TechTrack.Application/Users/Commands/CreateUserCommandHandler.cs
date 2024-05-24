using AutoMapper;
using MediatR;
using TechTrack.Application.Interfaces.Users;
using TechTrack.Domain.Models;

namespace TechTrack.Application.Users.Commands;
public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IUsersWriteRepository _userRepository;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(IUsersWriteRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<User>(request.User); 

        _userRepository.Add(user);

        return user.Id;
    }
}

