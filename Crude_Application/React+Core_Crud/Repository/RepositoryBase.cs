using Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repository {
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class {
        protected RepositoryContext repositoryContext;

        public RepositoryBase(RepositoryContext repositoryContext) {
            this.repositoryContext = repositoryContext;
        }

        public void Create(T entity) {
            repositoryContext.Set<T>().Add(entity);
        }

        public void Delete(T entity) {
            repositoryContext.Set<T>().Remove(entity);
        }

        public IQueryable<T> FindAll(bool trackChanges) {
            if (!trackChanges) {
                return repositoryContext
                    .Set<T>()
                    .AsNoTracking();
            }

            return repositoryContext
                    .Set<T>();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> condition, bool trackChanges) {
            if (!trackChanges) {
                return repositoryContext
                    .Set<T>()
                    .Where(condition)
                    .AsNoTracking();
            }

            return repositoryContext
                .Set<T>()
                .Where(condition);
        }

        public void Update(T entity) {
            repositoryContext.Set<T>().Update(entity);
        }
    }
}
