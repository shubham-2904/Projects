using Authentication.Domain.Model;
using Authentication.Infrastructure.DBContext;
using AuthenticationRepositories.Interfaces;
using System.Linq.Expressions;

namespace AuthenticationRepositories.Repositories;

public class UserLoginRepository(AuthenticationDbContext authenticationContext)
    : Repository<UserLogin>(authenticationContext), IUserLoginRepository
{
    public void CreateUserLogin(UserLogin userLogin)
    {
        throw new NotImplementedException();
    }

    public void DeleteUserLogin(long userLoginId)
    {
        throw new NotImplementedException();
    }

    public void UpdateUserLogin(UserLogin userLogin)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<UserLogin>> GetAllUserLoginAsync(Expression<Func<UserLogin, bool>>? condition, bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public Task<UserLogin> GetUserLoginByIdAsync(long userLoginId, bool trackChanges)
    {
        throw new NotImplementedException();
    }
}
