using Reference.Domain.Model;
using Reference.Infrastructure.DBContext;
using ReferenceRepositories.Interfaces;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace ReferenceRepositories.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(ReferenceDbContext referenceContext)
        : base(referenceContext) { }

    public void CreateUser(User user)
    {
        Create(user);
    }

    public void DeleteUser(User user)
    {
        Delete(user);
    }

    /// <summary>
    /// Get all records else if we pass value for condition parameter then it will return the records according to condition
    /// </summary>
    /// <param name="trackChanges"></param>
    /// <param name="condition"></param>
    /// <returns>return collection of User</returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<IEnumerable<User>> GetAllUserOrByConditionAsync(bool trackChanges, Expression<Func<User, bool>>? condition)
    {
        if (condition is not null)
        {
            return await FindByCondition(condition, trackChanges).ToListAsync();
        }
        else
        {
            return await FindAll(trackChanges).ToListAsync();
        }
    }

    public async Task<User?> GetUserByIdAsync(long userId, bool trackChanges)
    {
        return await FindByCondition(u => u.UserId.Equals(userId), trackChanges).SingleOrDefaultAsync();
    }

    public void UpdateUser(User user)
    {
        Update(user);
    }
}
