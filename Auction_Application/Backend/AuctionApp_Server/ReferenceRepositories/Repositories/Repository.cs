using Microsoft.EntityFrameworkCore;
using Reference.Infrastructure.DBContext;
using ReferenceRepositories.Interfaces;
using System.Linq.Expressions;

namespace ReferenceRepositories.Repositories;

public class Repository<T>(ReferenceDbContext context) : IRepository<T> where T : class
{
    private readonly ReferenceDbContext _referenceContext = context;

    public void Create(T entity)
    {
        _referenceContext.Set<T>().Add(entity);
    }

    public void Delete(T entity)
    {
        _referenceContext.Set<T>().Remove(entity);
    }

    public void Update(T entity)
    {
        _referenceContext.Set<T>().Update(entity);
    }

    public IQueryable<T> FindAll(bool trackChanges)
    {
        return !trackChanges
             ? _referenceContext.Set<T>().AsNoTracking()
             : _referenceContext.Set<T>();
    }

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
    {
        return !trackChanges
            ? _referenceContext.Set<T>().Where(expression).AsNoTracking()
            : _referenceContext.Set<T>().Where(expression);
    }
}
