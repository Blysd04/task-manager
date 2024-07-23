using task_manager.Dtos.User;
using task_manager.models;
namespace task_manager.mappers
{
    public static class UserMappers
    {
        public static UserDto ToUserDto(this User userModel)
        {
            return new UserDto
            {
                Id = userModel.Id,
                Name = userModel.Name,
                Email = userModel.Email,
                Tasks = userModel.Tasks.Select(s => s.ToTaskDto()).ToList()
            };
        }
        public static User ToUserFromCreateDTO(this CreateUserRequest userDto)
        {
            return new User
            {
                Name = userDto.Name,
                Email = userDto.Email,
                Password = userDto.Password
            };
        }
    }
}