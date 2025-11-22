using SharedData;
using SharedData.Dto;

namespace ServiceContracts
{
    public interface ITaskService
    {
        Task<Response<TaskDto>> CreateTaskAsync(TaskDto task);
        Task<Response<long>> UpdateTaskAsync(TaskDto task);
        Task<Response<long>> DeleteTaskAsync(long taskId);
        Task<Response<IEnumerable<TaskDto>>> GetAllTasksAsync(bool trackChanges);
        Task<Response<TaskDto>> GetTaskAsync(long taskId);
    }
}
