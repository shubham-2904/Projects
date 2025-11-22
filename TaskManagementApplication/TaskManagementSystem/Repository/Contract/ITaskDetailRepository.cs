using Entities.Model;
using System;
using System.Linq.Expressions;

namespace Repository.Contract
{
    public interface ITaskDetailRepository
    {
        Task<IEnumerable<TaskDetail>> GetAllTaskDetail(bool trackChanges, Expression<Func<TaskDetail, bool>> condition = null!);

        Task<TaskDetail?> GetTaskDetailByIdAsync(long taskDetailId, bool trackChanges);

        void CreateTaskDetail(TaskDetail taskDetail);

        void UpdateTaskDetail(TaskDetail taskDetail);

        void DeleteTaskDetail(TaskDetail taskDetail);

        Task<IEnumerable<TaskDetail>> GetAllTasksByTaskIdAsync(long taskId, bool trackChanges);
    }
}
