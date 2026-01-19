using Authentication.Domain.Model;
using System.Linq.Expressions;

namespace AuthenticationRepositories.Interfaces;

public interface IUserLoginRepository
{
    Task<IEnumerable<UserLogin>> GetAllUserLoginAsync(Expression<Func<UserLogin, bool>>? condition, bool trackChanges);
    Task<UserLogin> GetUserLoginByIdAsync(long userLoginId, bool trackChanges);
    void CreateUserLogin(UserLogin userLogin);
    void UpdateUserLogin(UserLogin userLogin);
    void DeleteUserLogin(long userLoginId);
}
