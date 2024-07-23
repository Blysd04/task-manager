using task_manager.Dtos.User;
using task_manager.models;

namespace task_manager.interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id); //FirstOrDefault
        Task<User> CreateAsync(User userModel);
        Task<User?> UpdateAsync(int id, UpdateUserRequest userRequest);
        Task<User?> DeleteAsync(int id);
        Task<bool> UserExists(int id);
        Task<bool> EmailExistsAsync(string email);
    }
}