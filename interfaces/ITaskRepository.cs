using task_manager.Dtos.Task;
using task_manager.models;
namespace task_manager.interfaces
{
    public interface ITaskRepository
    {
        Task<List<TaskToDo>> GetAllSync();
        Task<TaskToDo?> GetByIdAsync(int id); //FirstOrDefault
        Task<TaskToDo> CreateAsync(TaskToDo taskModel);
        Task<TaskToDo?> UpdateAsync(int id, UpdateTaskRequest taskRequest);
        Task<TaskToDo?> DeleteAsync(int id);
    }
}