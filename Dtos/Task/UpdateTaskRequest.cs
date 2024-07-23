using System.ComponentModel.DataAnnotations;

namespace task_manager.Dtos.Task
{
    public class UpdateTaskRequest
    {
        [Required]
        [MinLength(2, ErrorMessage = "Name Task must be 2 characters")]
        [MaxLength(50, ErrorMessage = "Name Task cannot be over 50 characters")]
        public string NameTask { get; set; } = string.Empty;

        [MaxLength(50, ErrorMessage = "Description cannot be over 100 characters")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Range(typeof(bool), "false", "true")]
        public bool Status { get; set; } = false;
    }
}