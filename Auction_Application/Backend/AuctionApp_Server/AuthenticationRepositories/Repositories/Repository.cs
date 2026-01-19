using Authentication.Infrastructure.DBContext;
using AuthenticationRepositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AuthenticationRepositories.Repositories;

public class Repository<T>(AuthenticationDbContext context) : IRepository<T> where T : class
{
    private readonly AuthenticationDbContext _authenticationContext = context;

    public async Task CreateAsync(T entity)
    {
        await _authenticationContext.Set<T>().AddAsync(entity);
    }

    public void Delete(T entity)
    {
       _authenticationContext.Set<T>().Remove(entity);
    }

    public void Update(T entity)
    {
        _authenticationContext.Set<T>().Update(entity);
    }

    public IQueryable<T> FindAllAsync(bool trackChanges)
    {
        return !trackChanges
             ? _authenticationContext.Set<T>().AsNoTracking()
             : _authenticationContext.Set<T>();
    }

    public IQueryable<T> FindByConditionAsync(Expression<Func<T, bool>> expression, bool trackChanges)
    {
        return !trackChanges
            ? _authenticationContext.Set<T>().Where(expression).AsNoTracking()
            : _authenticationContext.Set<T>().Where(expression);
    }
}
