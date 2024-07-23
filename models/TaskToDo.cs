namespace task_manager.models
{
    public class TaskToDo
    {
        public int Id { get; set; }
        public string NameTask { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool Status { get; set; } = false;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public int? UserId { get; set; }
        public User? User { get; set; }
    }
}