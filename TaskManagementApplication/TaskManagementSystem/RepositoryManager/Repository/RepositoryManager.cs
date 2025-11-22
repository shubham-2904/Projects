using Repository;
using Repository.Contract;
using Repository.Repository;
using RepositoryManager.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryManager.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly TaskManagerContext _taskManagerContext;

        private readonly Lazy<ITaskRepository> _taskRepository;
        private readonly Lazy<ITaskDetailRepository> _taskDetailRepository;

        public RepositoryManager(TaskManagerContext context) 
        { 
            _taskManagerContext = context;

            _taskRepository = new Lazy<ITaskRepository>(() => new TaskRepository(_taskManagerContext));
            _taskDetailRepository = new Lazy<ITaskDetailRepository>(() => new TaskDetailRepository(_taskManagerContext));
        }

        public ITaskRepository Task => _taskRepository.Value;
        public ITaskDetailRepository TaskDetail => _taskDetailRepository.Value;

        public async Task CommitAsync()
        {
            await _taskManagerContext.SaveChangesAsync();
        }
    }
}
