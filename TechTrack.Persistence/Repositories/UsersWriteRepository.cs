using TechTrack.Application.Interfaces.Users;
using TechTrack.Domain.Models;
using TechTrack.Persistence.DatabaseContext;

namespace TechTrack.Persistence.Repositories;
public class UsersWriteRepository : IUsersWriteRepository
{
    private readonly WriteDbContext _dbContext;

    public UsersWriteRepository(WriteDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(User user)
    {
        _dbContext.Add(user);   
        _dbContext.SaveChanges();   
    }
}
