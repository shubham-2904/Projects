using Entities.Model;
using SharedData.Dto;

namespace SharedData
{
    public static class TaskDetailMapper
    {
        public static TaskDetailDto ToDto(this TaskDetail taskDetail)
        {
            return new TaskDetailDto
            {
                Id = taskDetail.Id,
                TaskId = taskDetail.TaskId,
                Detail = taskDetail.Detail,
                IsCompleted = taskDetail.IsCompleted,
            };
        }

        public static IEnumerable<TaskDetailDto> ToDtos(this IEnumerable<TaskDetail> taskDetail)
        {
            List<TaskDetailDto> taskDetailDtoList = new List<TaskDetailDto>();
            foreach (var item in taskDetail)
            {
                taskDetailDtoList.Add(ToDto(item));
            }
            return taskDetailDtoList;
        }

        public static TaskDetail ToEntity(this TaskDetailDto taskDetailDto)
        {
            return new TaskDetail
            {
                Id = taskDetailDto.Id,
                TaskId = taskDetailDto.TaskId,
                Detail = taskDetailDto.Detail,
                IsCompleted = taskDetailDto.IsCompleted
            };
        }

        public static IEnumerable<TaskDetail> ToEntities(this IEnumerable<TaskDetailDto> taskDetailDto)
        {
            List<TaskDetail> taskDetailList = new List<TaskDetail>();
            foreach (var item in taskDetailDto)
            {
                taskDetailList.Add(ToEntity(item));
            }
            return taskDetailList;
        }
    }
}
