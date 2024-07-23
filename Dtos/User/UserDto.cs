using task_manager.Dtos.Task;

namespace task_manager.Dtos.User
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<TaskDto> Tasks { get; set; }
    }
}