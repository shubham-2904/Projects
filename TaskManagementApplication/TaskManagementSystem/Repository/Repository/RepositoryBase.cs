using Microsoft.EntityFrameworkCore;
using Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private TaskManagerContext _taskManagerContext;

        public RepositoryBase(TaskManagerContext context)
        {
            _taskManagerContext = context;
        }

        public void Create(T entity)
        {
            _taskManagerContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _taskManagerContext.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _taskManagerContext.Set<T>().Update(entity);
        }

        public IQueryable<T> FindAll(bool trackChanges)
        {
            return !trackChanges
                ? _taskManagerContext.Set<T>().AsNoTracking()
                : _taskManagerContext.Set<T>();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return !trackChanges
                ? _taskManagerContext.Set<T>().Where(expression).AsNoTracking()
                : _taskManagerContext.Set<T>().Where(expression);
        }
    }
}
