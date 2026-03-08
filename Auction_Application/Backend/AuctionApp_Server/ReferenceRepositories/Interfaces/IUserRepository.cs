using Reference.Domain.Model;
using System.Linq.Expressions;

namespace ReferenceRepositories.Interfaces;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllUserOrByConditionAsync(bool trackChanges, Expression<Func<User, bool>>? condition);

    Task<User> GetUserByIdAsync(long userId, bool trackChanges);

    void CreateUser(User user);

    void UpdateUser(User user);

    void DeleteUser(User user);
}
