using System.Linq.Expressions;

namespace AuthenticationRepositories.Interfaces;

public interface IRepository<T> where T : class
{
    IQueryable<T> FindByConditionAsync(Expression<Func<T, bool>> expression, bool trackChanges);
    IQueryable<T> FindAllAsync(bool trackChanges);
    Task CreateAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
}
