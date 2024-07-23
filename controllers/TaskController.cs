using Microsoft.AspNetCore.Mvc;
using task_manager.datas;
using task_manager.Dtos.Task;
using task_manager.interfaces;
using task_manager.mappers;
namespace task_manager.controllers
{
    [Route("api/task")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepo;
        private readonly IUserRepository _userRepo;
        public TaskController(IUserRepository userRepo, ITaskRepository taskRepo)
        {
            _taskRepo = taskRepo;
            _userRepo = userRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tasks = await _taskRepo.GetAllSync();
            var taskDto = tasks.Select(s => s.ToTaskDto());
            return Ok(taskDto);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var task = await _taskRepo.GetByIdAsync(id);
            if (task == null)
            {
                return NotFound("Task does not exist!");
            }
            return Ok(task.ToTaskDto());
        }

        [HttpPost]
        [Route("{userId:int}")]
        public async Task<IActionResult> CreateTask([FromRoute] int userId, [FromBody] CreateTaskRequest taskDto)
        {
            if (!await _userRepo.UserExists(userId))
            {
                return BadRequest("User does not exist!");
            }
            var taskModel = taskDto.ToTaskFromCreateDto(userId);
            await _taskRepo.CreateAsync(taskModel);
            return CreatedAtAction(nameof(GetById), new { id = taskModel.Id }, taskModel.ToTaskDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateTask([FromRoute] int id, [FromBody] UpdateTaskRequest update)
        {
            var taskModel = await _taskRepo.UpdateAsync(id, update);
            if (taskModel == null)
            {
                return NotFound("Task does not exist!");
            }

            return Ok(taskModel.ToTaskDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteTask([FromRoute] int id)
        {
            var taskModel = await _taskRepo.DeleteAsync(id);
            if (taskModel == null)
            {
                return NotFound("Task does not exist!");
            }
            return Ok(taskModel);
        }
    }
}