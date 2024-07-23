using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using task_manager.datas;
using task_manager.Dtos.User;
using task_manager.interfaces;
using task_manager.models;


namespace task_manager.repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _context;
        public UserRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.User.Include(s => s.Tasks).ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.User.Include(s => s.Tasks).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<User?> UpdateAsync(int id, UpdateUserRequest userRequest)
        {
            var existingUser = await _context.User.FirstOrDefaultAsync(s => s.Id == id);
            if (existingUser == null)
            {
                return null;
            }

            existingUser.Name = userRequest.Name;
            existingUser.Email = userRequest.Email;
            existingUser.Password = userRequest.Password;
            await _context.SaveChangesAsync();
            return existingUser;
        }

        public async Task<User> CreateAsync(User userModel)
        {
            await _context.User.AddAsync(userModel);
            await _context.SaveChangesAsync();
            return userModel;
        }

        public async Task<User?> DeleteAsync(int id)
        {
            var userModel = await _context.User.FirstOrDefaultAsync(s => s.Id == id);
            if (userModel == null)
            {
                return null;
            }
            _context.User.Remove(userModel);
            await _context.SaveChangesAsync();
            return userModel;
        }

        public Task<bool> UserExists(int id)
        {
            return _context.User.AnyAsync(s => s.Id == id);
        }
        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _context.User.AnyAsync(u => u.Email == email);
        }
    }
}