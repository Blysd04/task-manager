using task_manager.models;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
namespace task_manager.Dtos.User
{
    public class CreateUserRequest
    {
        [Required]
        [MinLength(2, ErrorMessage = "Name must be 2 characters")]
        [MaxLength(50, ErrorMessage = "Name cannot be over 50 characters")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [MinLength(10, ErrorMessage = "Email must be 10 characters")]
        [MaxLength(100, ErrorMessage = "Email cannot be over 100 characters")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MinLength(6, ErrorMessage = "Password must be 6 characters")]
        [MaxLength(30, ErrorMessage = "Password cannot be over 30 characters")]
        public string Password { get; set; } = string.Empty;
    }
}