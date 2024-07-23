// using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using task_manager.datas;
using task_manager.Dtos.User;
using task_manager.interfaces;
using task_manager.mappers;

namespace task_manager.controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        public UserController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userRepo.GetAllAsync();
            var userDto = users.Select(s => s.ToUserDto());
            return Ok(userDto);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var user = await _userRepo.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound("User does not exist!");
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest userDto)
        {
            if (await _userRepo.EmailExistsAsync(userDto.Email))
            {
                return BadRequest("Email already exists.");
            }
            var userModel = userDto.ToUserFromCreateDTO();
            await _userRepo.CreateAsync(userModel);
            return CreatedAtAction(nameof(GetById), new { id = userModel.Id }, userModel.ToUserDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateUser([FromRoute] int id, [FromBody] UpdateUserRequest update)
        {
            if (await _userRepo.EmailExistsAsync(update.Email))
            {
                return BadRequest("Email already exists.");
            }
            var userModel = await _userRepo.UpdateAsync(id, update);
            if (userModel == null)
            {
                return NotFound("User does not exist!");
            }

            return Ok(userModel.ToUserDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            var userModel = await _userRepo.DeleteAsync(id);
            if (userModel == null)
            {
                return NotFound("User does not exist!");
            }
            return Ok(userModel);
        }
    }
}