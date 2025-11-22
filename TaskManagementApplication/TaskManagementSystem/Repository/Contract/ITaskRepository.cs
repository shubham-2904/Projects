using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contract
{
    public interface ITaskRepository
    {
        Task<IEnumerable<Entities.Model.Task>> GetAllTasksAsync(bool trackChanges, Expression<Func<Entities.Model.Task, bool>> codition = null);

        Task<Entities.Model.Task> GetTaskByIdAsync(long taskId, bool trackChanges);

        void CreateTask(Entities.Model.Task task);

        void UpdateTask(Entities.Model.Task task);

        void DeleteTask(Entities.Model.Task task);
    }
}
