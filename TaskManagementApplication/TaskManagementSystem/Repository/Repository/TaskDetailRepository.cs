using Entities.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Repository.Contract;
using System.Linq.Expressions;

namespace Repository.Repository
{
    public class TaskDetailRepository : RepositoryBase<TaskDetail>, ITaskDetailRepository
    {
        public TaskDetailRepository(TaskManagerContext context) : base(context) 
        {
        }

        public void CreateTaskDetail(TaskDetail taskDetail)
        {
            Create(taskDetail);
        }

        public void DeleteTaskDetail(TaskDetail taskDetail)
        {
            Delete(taskDetail);
        }

        public async Task<IEnumerable<TaskDetail>> GetAllTaskDetail(bool trackChanges, Expression<Func<TaskDetail, bool>> condition = null!)
        {
            if (condition is null)
            {
                return await FindAll(trackChanges).ToListAsync();
            } else
            {
                return await FindByCondition(condition, trackChanges).ToListAsync();
            }
        }

        public async Task<IEnumerable<TaskDetail>> GetAllTasksByTaskIdAsync(long taskId, bool trackChanges)
        {
            return await FindByCondition(td => td.TaskId.Equals(taskId), trackChanges).ToListAsync();
        }

        public async Task<TaskDetail?> GetTaskDetailByIdAsync(long taskDetailId, bool trackChanges)
        {
            return await FindByCondition(td => td.Id.Equals(taskDetailId), trackChanges).SingleOrDefaultAsync();
        }

        public void UpdateTaskDetail(TaskDetail taskDetail)
        {
            Update(taskDetail);
        }
    }
}
