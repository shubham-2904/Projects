using SharedData;
using SharedData.Dto;

namespace ServiceContracts
{
    public interface ITaskDetailService
    {
        Task<Response<TaskDetailDto>> GetTaskDetailByIdAsync(long taskDetailId);        

        Task<Response<long>> UpdateTaskDetailAsync(TaskDetailDto taskDetailDto);

        Task<Response<long>> DeleteTaskDetailAsync(long taskDetailId);

        Task<Response<bool>> MarkTaskCompleteOrUnCompleteAsync(long taskDetailId);

        Task<Response<TaskDetailDto>> CreateTaskDetailAsync(TaskDetailDto taskDetailDto);

    }
}
