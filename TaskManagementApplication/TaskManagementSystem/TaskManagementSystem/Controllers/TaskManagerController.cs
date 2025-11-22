using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using SharedData.Dto;
using TaskManagementSystem.ActionFilter;

namespace TaskManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskManagerController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public TaskManagerController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        [Route("ApiHealth")]
        public IActionResult Get(int number) => Ok("TaskManager api is running...");

        #region <---------- TASK ENDPOINT ---------->

        [HttpGet]
        [Route("get-all-tasks")]
        public async Task<IActionResult> GetAllTaskAsync()
        {
            var tasks = await _serviceManager.TaskService.GetAllTasksAsync(false);
            return Ok(tasks);
        }

        [HttpGet("get-task/{id:long}")]
        public async Task<IActionResult> GetTaskByIdAsync(long id)
        {
            var task = await _serviceManager.TaskService.GetTaskAsync(id);
            return Ok(task);
        }

        [HttpPost]
        [Route("create-task")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateTaskAsync([FromBody] TaskDto taskDto)
        {
            if (taskDto == null)
            {
                return BadRequest("TaskDto object is null");
            }

            var task = await _serviceManager.TaskService.CreateTaskAsync(taskDto);
            return Ok(task);
        }

        [HttpPost]
        [Route("update-task")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateTaskAsync([FromBody] TaskDto taskDto)
        {
            if (taskDto == null)
            {
                return BadRequest("TaskDto object is null");
            }

            var task = await _serviceManager.TaskService.UpdateTaskAsync(taskDto);
            return Ok(task);
        }

        [HttpDelete]
        [Route("delete-task/{id:long}")]
        public async Task<IActionResult> DeleteTaskAsync([FromRoute] long id)
        {
            var task = await _serviceManager.TaskService.DeleteTaskAsync(id);
            return Ok(task);
        }

        #endregion

        #region <---------- TASKDETAIL ENDPOINT ---------->

        [HttpGet("get-task-detail/{id:long}")]
        public async Task<IActionResult> GetTaskDetailById(long id)
        {
            var taskDetail = await _serviceManager.TaskDetailService.GetTaskDetailByIdAsync(id);
            return Ok(taskDetail);
        }

        [HttpPost("create-task-detail")]
        public async Task<IActionResult> CreateTaskDetailAsync([FromBody] TaskDetailDto taskDetailDto)
        {
            var response = await _serviceManager.TaskDetailService.CreateTaskDetailAsync(taskDetailDto);
            return Ok(response);
        }

        [HttpPost("update-task-detail")]
        public async Task<IActionResult> UpdateTaskDetailAsync([FromBody] TaskDetailDto taskDetailDto)
        {
            var response = await _serviceManager.TaskDetailService.UpdateTaskDetailAsync(taskDetailDto);
            return Ok(response);
        }

        [HttpDelete("delete-task-detail/{id:long}")]
        public async Task<IActionResult> DeleteTaskDetailByIdAsync([FromRoute] long id)
        {
            var response = await _serviceManager.TaskDetailService.DeleteTaskDetailAsync(id);
            return Ok(response);
        }

        [HttpPost("mark-task-detail/{id:long}")]
        public async Task<IActionResult> MarkTaskDetailAsync([FromRoute] long id)
        {
            var response = await _serviceManager.TaskDetailService.MarkTaskCompleteOrUnCompleteAsync(id);
            return Ok(response);
        }

        #endregion
    }
}
