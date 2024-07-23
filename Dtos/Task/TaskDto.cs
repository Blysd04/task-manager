namespace task_manager.Dtos.Task
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string NameTask { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool Status { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public int? UserId { get; set; }
    }
}