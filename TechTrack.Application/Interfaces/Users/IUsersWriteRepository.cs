using TechTrack.Domain.Models;

namespace TechTrack.Application.Interfaces.Users;
public interface IUsersWriteRepository 
{
    void Add(User user);
}
