using SharedData.Dto;

namespace SharedData
{
    public static class TaskMapper
    {
        public static TaskDto ToDto(this Entities.Model.Task task)
        {
            return new TaskDto
            {
                Id = task.Id,
                Category = task.Category,
                CreateDate = task.CreateDate,
                Title = task.Title,
                Description = task.Description,
                Details = task.Details?.ToDtos()
            };
        }

        public static IEnumerable<TaskDto> ToDtos(this IEnumerable<Entities.Model.Task> tasks)
        {
            List<TaskDto> taskDtoList = new List<TaskDto>();
            foreach (var task in tasks)
            {
                taskDtoList.Add(ToDto(task));
            }
            return taskDtoList;
        }

        public static Entities.Model.Task ToEntity(this TaskDto taskDto)
        {
            return new Entities.Model.Task
            {
                Id = taskDto.Id,
                Category = taskDto.Category,
                CreateDate = taskDto.CreateDate,
                Title = taskDto.Title,
                Description = taskDto.Description,
                Details = taskDto.Details?.ToEntities()?.ToList()
            };
        }

        public static IEnumerable<Entities.Model.Task> ToEntities(this IEnumerable<TaskDto> taskDtos)
        {
            List<Entities.Model.Task> taskList = new List<Entities.Model.Task>();
            foreach (var taskDto in taskDtos)
            {
                taskList.Add(ToEntity(taskDto));
            }
            return taskList;
        }
    }
}
