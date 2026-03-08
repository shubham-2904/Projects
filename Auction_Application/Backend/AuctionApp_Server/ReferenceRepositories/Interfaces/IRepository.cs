using System.Linq.Expressions;

namespace ReferenceRepositories.Interfaces;

public interface IRepository<T> where T : class
{
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);

    IQueryable<T> FindAll(bool trackChanges);

    void Create(T entity);

    void Update(T entity);

    void Delete(T entity);
}
