using Entities.Model;
using Entities.Exceptions;
using RepositoryManager.Contract;
using ServiceContracts;
using SharedData;
using SharedData.Dto;
using LoggerService;

namespace Service
{
    internal sealed class TaskDetailService : ITaskDetailService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;

        public TaskDetailService(IRepositoryManager repositoryManager, ILoggerManager loggerManager)
        {
            _repositoryManager = repositoryManager;
            _loggerManager = loggerManager;
        }

        public async Task<Response<TaskDetailDto>> CreateTaskDetailAsync(TaskDetailDto taskDetailDto)
        {
            try
            {
                TaskDetail taskDetailEntity = taskDetailDto.ToEntity();

                _repositoryManager.TaskDetail.CreateTaskDetail(taskDetailEntity);
                await _repositoryManager.CommitAsync();

                var response = taskDetailEntity.ToDto();
                return Response<TaskDetailDto>.Ok(response, "Task Detail created succefully");
            } catch (Exception ex)
            {
                _loggerManager.LogError($"Exception in method CreateTaskDetailAsync: Message => {ex.Message}; Inner Message => {ex.InnerException}");
                return Response<TaskDetailDto>.Fail("Error occured while creating task detail");
            }
        }

        public async Task<Response<long>> DeleteTaskDetailAsync(long taskDetailId)
        {
            try
            {
                TaskDetail? taskDetail = await _repositoryManager.TaskDetail.GetTaskDetailByIdAsync(taskDetailId, true);
                if (taskDetail == null || taskDetail.IsDeleted == true)
                {
                    _loggerManager.LogError($"Task Detail is not present or delete from DB task id: {taskDetailId}");
                    throw new TaskDetailNotFound(taskDetailId);
                }
                taskDetail.IsDeleted = true;
                taskDetail.LastModifyDate = DateTime.Now;

                await _repositoryManager.CommitAsync();

                return Response<long>.Ok(taskDetailId, "Task Detail deleted succesfully");
            } catch (Exception ex)
            {
                _loggerManager.LogError($"Exception in method DeleteTaskDetail: Message => {ex.Message}; Inner Message => {ex.InnerException}");
                return Response<long>.Fail("Error occured while deleting task detail");
            }
        }

        public async Task<Response<TaskDetailDto>> GetTaskDetailByIdAsync(long taskDetailId)
        {
            try
            {
                TaskDetail? taskDetail = await _repositoryManager.TaskDetail.GetTaskDetailByIdAsync(taskDetailId, false);
                if (taskDetail == null || taskDetail.IsDeleted == true)
                {
                    _loggerManager.LogError($"Task Detail is not present or delete from DB task id: {taskDetailId}");
                    throw new TaskDetailNotFound(taskDetailId);
                }

                TaskDetailDto taskDetasilDto = taskDetail.ToDto();
                return Response<TaskDetailDto>.Ok(taskDetasilDto, "Task Detail fetched sucessfully");
            } catch (Exception ex)
            {
                _loggerManager.LogError($"Exception in method GetTaskDetailByIdAsync: Message => {ex.Message}; Inner Message => {ex.InnerException}");
                return Response<TaskDetailDto>.Fail("Error occured while fetching task detail");
            }
        }

        public async Task<Response<bool>> MarkTaskCompleteOrUnCompleteAsync(long taskDetailId)
        {
            try
            {
                TaskDetail? taskDetail = await _repositoryManager.TaskDetail.GetTaskDetailByIdAsync(taskDetailId, true);
                if (taskDetail is null || taskDetail.IsDeleted == true)
                {
                    _loggerManager.LogError($"Task Detail is not present or delete from DB task id: {taskDetailId}");
                    throw new TaskDetailNotFound(taskDetailId);
                }

                if (!taskDetail.IsCompleted)
                {
                    taskDetail.LastModifyDate = DateTime.Now;
                    taskDetail.IsCompleted = true;
                } else
                {
                    taskDetail.LastModifyDate = DateTime.Now;
                    taskDetail.IsCompleted = false;
                }

                await _repositoryManager.CommitAsync();
                return Response<bool>.Ok(true, "Changing task detail status from completed to uncomplete or visa versa succefull");
            } catch (Exception ex)
            {
                _loggerManager.LogError($"Exception in method MarkTaskCompleteOrUnComplete: Message => {ex.Message}; Inner Message => {ex.InnerException}");
                return Response<bool>.Fail("Error occured while changing task detail status from completed to uncomplete or visa versa");
            }
        }

        public async Task<Response<long>> UpdateTaskDetailAsync(TaskDetailDto taskDetailDto)
        {
            try
            {
                TaskDetail? taskDetail = await _repositoryManager.TaskDetail.GetTaskDetailByIdAsync(taskDetailDto.Id, true);
                if (taskDetail is null || taskDetail.IsDeleted == true)
                {
                    _loggerManager.LogError($"Task Detail is not present or delete from DB task id: {taskDetailDto.Id}");
                    throw new TaskDetailNotFound(taskDetailDto.Id);
                }

                taskDetail.Detail = taskDetailDto.Detail;
                taskDetail.IsCompleted = taskDetailDto.IsCompleted;
                taskDetail.LastModifyDate = DateTime.Now;
                await _repositoryManager.CommitAsync();

                return Response<long>.Ok(taskDetailDto.Id, "Task Detail modify successfully");
            } catch (Exception ex)
            {
                _loggerManager.LogError($"Exception in method UpdateTaskDetail: Message => {ex.Message}; Inner Message => {ex.InnerException}");
                return Response<long>.Fail("Error occured while updating task detail");
            }
        }

    }
}
