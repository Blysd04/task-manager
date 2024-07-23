using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using task_manager.datas;
using task_manager.Dtos.Task;
using task_manager.interfaces;
using task_manager.models;
namespace task_manager.repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDBContext _context;
        public TaskRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<TaskToDo>> GetAllSync()
        {
            return await _context.TaskToDo.ToListAsync();
        }

        public async Task<TaskToDo?> GetByIdAsync(int id)
        {
            return await _context.TaskToDo.FindAsync(id);
        }

        public async Task<TaskToDo?> UpdateAsync(int id, UpdateTaskRequest taskRequest)
        {
            var existingTask = await _context.TaskToDo.FirstOrDefaultAsync(s => s.Id == id);
            if (existingTask == null)
            {
                return null;
            }

            existingTask.NameTask = taskRequest.NameTask;
            existingTask.Description = taskRequest.Description;
            existingTask.Status = taskRequest.Status;
            await _context.SaveChangesAsync();
            return existingTask;
        }

        public async Task<TaskToDo> CreateAsync(TaskToDo taskModel)
        {
            await _context.TaskToDo.AddAsync(taskModel);
            await _context.SaveChangesAsync();
            return taskModel;
        }

        public async Task<TaskToDo?> DeleteAsync(int id)
        {
            var taskModel = await _context.TaskToDo.FirstOrDefaultAsync(s => s.Id == id);
            if (taskModel == null)
            {
                return null;
            }
            _context.TaskToDo.Remove(taskModel);
            await _context.SaveChangesAsync();
            return taskModel;
        }

    }
}