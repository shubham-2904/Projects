using Repository.Contract;

namespace RepositoryManager.Contract
{
    public interface IRepositoryManager
    {
        ITaskRepository Task { get; }
        ITaskDetailRepository TaskDetail{ get; }

        /// <summary>
        /// Used to save changes into DB
        /// </summary>
        Task CommitAsync();
    }
}
