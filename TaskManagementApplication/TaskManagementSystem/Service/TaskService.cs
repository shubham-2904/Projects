using Entities.Model;
using RepositoryManager.Contract;
using ServiceContracts;
using SharedData;
using SharedData.Dto;
using Entities.Exceptions;
using LoggerService;

namespace Service
{
    internal sealed class TaskService : ITaskService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;

        public TaskService(IRepositoryManager repositoryManager, ILoggerManager loggerManager)
        {
            _repositoryManager = repositoryManager;
            _loggerManager = loggerManager;
        }

        public async Task<Response<TaskDto>> CreateTaskAsync(TaskDto task)
        {
            Entities.Model.Task taskEntity = task.ToEntity();
            try
            {
                taskEntity.LastModifyDate = DateTime.Now;

                if (taskEntity.Details is not null)
                {
                    foreach (TaskDetail td in taskEntity.Details)
                    {
                        td.LastModifyDate = DateTime.Now;
                    }
                }

                _repositoryManager.Task.CreateTask(taskEntity);
                await _repositoryManager.CommitAsync();
            } catch (Exception ex)
            {
                _loggerManager.LogError($"Execption log in method CreateTaskAsync Message => {ex.Message}; Inner Exception {ex.InnerException}");
                return Response<TaskDto>.Fail("Error occured while creating task");
            }

            TaskDto taskToReturn = taskEntity.ToDto();
            return Response<TaskDto>.Ok(taskToReturn, "Task created successfully");
        }

        public async Task<Response<long>> DeleteTaskAsync(long taskId)
        {
            try
            {
                Entities.Model.Task task = await _repositoryManager.Task.GetTaskByIdAsync(taskId, true);
                if (task is null)
                {
                    throw new TaskNotFound(taskId);
                }
                task.IsDeleted = true;
                task.LastModifyDate = DateTime.Now;

                task.Details = (await _repositoryManager.TaskDetail.GetAllTasksByTaskIdAsync(taskId, true)).ToList();
                if (task.Details is not null && task.Details.Count > 0)
                {
                    foreach (var taskDetail in task.Details)
                    {
                        taskDetail.IsDeleted = true;
                        taskDetail.LastModifyDate = DateTime.Now;
                    }
                }

                await _repositoryManager.CommitAsync();
            } catch (Exception ex)
            {
                _loggerManager.LogError($"Execption log in method DeleteTaskAsync Message => {ex.Message}; Inner Exception {ex.InnerException}");
                return Response<long>.Fail("Error occured while deleting task");
            }

            return Response<long>.Ok(taskId, "Task deleted successfully");
        }

        public async Task<Response<IEnumerable<TaskDto>>> GetAllTasksAsync(bool trackChanges)
        {
            try
            {
                IEnumerable<Entities.Model.Task> taskEntities = (await _repositoryManager.Task.GetAllTasksAsync(trackChanges, t => t.IsDeleted.Equals(false))).ToList();

                long[] taskIds = taskEntities.Select(t => t.Id).ToArray();
                IEnumerable<TaskDetail> allTaskDetails = await _repositoryManager.TaskDetail.GetAllTaskDetail(trackChanges, td => td.IsDeleted.Equals(false) && taskIds.Contains(td.TaskId));

                Dictionary<long, List<TaskDetail>>? taskDetailGroup = allTaskDetails
                    .GroupBy(td => td.TaskId)
                    .ToDictionary(g => g.Key, g => g.ToList());

                foreach (var task in taskEntities)
                {
                    task.Details = taskDetailGroup.TryGetValue(task.Id, out List<TaskDetail>? details)
                        ? details
                        : new List<TaskDetail>();
                }

                var taskDtos = taskEntities?.ToDtos();
                return Response<IEnumerable<TaskDto>>.Ok(taskDtos!, "All task fetched successfully");
            } catch (Exception ex)
            {
                _loggerManager.LogError($"Execption log in method GetAllTasksAsync Message => {ex.Message}; Inner Exception {ex.InnerException}");
                return Response<IEnumerable<TaskDto>>.Fail("Error occured while fetching tasks");
            }
        }

        public async Task<Response<TaskDto>> GetTaskAsync(long taskId)
        {
            try
            {
                var taskEntity = await _repositoryManager.Task.GetTaskByIdAsync(taskId, false);
                if (taskEntity is null || taskEntity.IsDeleted)
                {
                    _loggerManager.LogError($"Task is not present or delete from DB task id: {taskId}");
                    throw new TaskNotFound(taskId);
                }

                taskEntity.Details =
                    (await _repositoryManager.TaskDetail.GetAllTaskDetail(false, td => td.TaskId.Equals(taskEntity.Id) && td.IsDeleted.Equals(false))).ToList();

                return Response<TaskDto>.Ok(taskEntity.ToDto(), "Task fetched successfully");
            } catch (Exception ex)
            {
                _loggerManager.LogError($"Execption log in method GetTaskAsync Message => {ex.Message}; Inner Exception {ex.InnerException}");
                return Response<TaskDto>.Fail("Error occured while fetching task");
            }
        }

        public async Task<Response<long>> UpdateTaskAsync(TaskDto task)
        {
            try
            {
                Entities.Model.Task taskEntity = await _repositoryManager.Task.GetTaskByIdAsync(task.Id, true);

                if (taskEntity is null)
                {
                    _loggerManager.LogError($"Task is not present or delete from DB task id: {task.Id}");
                    throw new Exception("Entity not present");
                }

                taskEntity.LastModifyDate = DateTime.Now;
                taskEntity.Category = task.Category;
                taskEntity.Title = task.Title;
                taskEntity.Description = task.Description;

                _repositoryManager.Task.UpdateTask(taskEntity);
                await _repositoryManager.CommitAsync();

                return Response<long>.Ok(task.Id, "Task modified successfully");
            } catch (Exception ex)
            {
                _loggerManager.LogError($"Execption log in method GetTaskAsync Message => {ex.Message}; Inner Exception {ex.InnerException}");
                return Response<long>.Fail("Error occured while fetching task");
            }
        }
    }
}
