using Microsoft.EntityFrameworkCore;
using Repository.Contract;
using System.Linq.Expressions;

namespace Repository.Repository
{
    public class TaskRepository : RepositoryBase<Entities.Model.Task>, ITaskRepository
    {
        public TaskRepository(TaskManagerContext context) : base(context)
        {
        }

        public void CreateTask(Entities.Model.Task task)
        {
            Create(task);
        }

        public void DeleteTask(Entities.Model.Task task)
        {
            Delete(task);
        }

        public async Task<IEnumerable<Entities.Model.Task>> GetAllTasksAsync(bool trackChanges, Expression<Func<Entities.Model.Task, bool>> codition = null)
        {
            if (codition == null)
            {
                return await FindAll(trackChanges).ToListAsync();
            }
            else
            {
                return await FindByCondition(codition, trackChanges).ToListAsync();
            }
        }

        public async Task<Entities.Model.Task> GetTaskByIdAsync(long taskId, bool trackChanges)
        {
            return await FindByCondition(t => t.Id.Equals(taskId), trackChanges).SingleOrDefaultAsync();
        }

        public void UpdateTask(Entities.Model.Task task)
        {
            Update(task);
        }
    }
}
