using System.ComponentModel.DataAnnotations;

namespace task_manager.Dtos.Task
{
    public class CreateTaskRequest
    {
        [Required]
        [MinLength(2, ErrorMessage = "Name Task must be 2 characters")]
        [MaxLength(50, ErrorMessage = "Name Task cannot be over 50 characters")]
        public string NameTask { get; set; } = string.Empty;

        [MaxLength(50, ErrorMessage = "Description cannot be over 100 characters")]
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedOn { get; } = DateTime.Now;
        public bool Status { get; } = false;
    }
}