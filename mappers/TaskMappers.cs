using task_manager.models;
using task_manager.Dtos.Task;
namespace task_manager.mappers
{
    public static class TaskMappers
    {
        public static TaskDto ToTaskDto(this TaskToDo taskModel)
        {
            return new TaskDto
            {
                Id = taskModel.Id,
                NameTask = taskModel.NameTask,
                Description = taskModel.Description,
                Status = taskModel.Status,
                CreatedOn = taskModel.CreatedOn,
                UserId = taskModel.UserId
            };
        }
        public static TaskToDo ToTaskFromCreateDto(this CreateTaskRequest taskDto, int userId)
        {
            return new TaskToDo
            {
                NameTask = taskDto.NameTask,
                Description = taskDto.Description,
                Status = taskDto.Status,
                CreatedOn = taskDto.CreatedOn,
                UserId = userId
            };
        }
    }
}