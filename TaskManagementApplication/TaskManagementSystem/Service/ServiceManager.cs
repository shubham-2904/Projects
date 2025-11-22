using LoggerService;
using RepositoryManager.Contract;
using ServiceContracts;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<ITaskService> _taskService;
        private readonly Lazy<ITaskDetailService> _taskDetailService;

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager loggerManager)
        {
            _taskService = new Lazy<ITaskService>(() => new TaskService(repositoryManager, loggerManager));
            _taskDetailService = new Lazy<ITaskDetailService>(() => new TaskDetailService(repositoryManager, loggerManager));
        }

        public ITaskService TaskService => _taskService.Value;

        public ITaskDetailService TaskDetailService => _taskDetailService.Value;
    }
}
