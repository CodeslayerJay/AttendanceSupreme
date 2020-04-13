using AttendanceSupreme.Engine.Entities;
using AttendanceSupreme.Services.DTOs;
using AttendanceSupreme.Services.ValidationSpecs;

namespace AttendanceSupreme.Services
{
    public interface IUserService
    {
        ValidationResult CreateUser(UserDTO userDTO);
        User GetUser(int userId);
        User GetUser(string firstname, string lastname, int? lastFourSSN = null);
        User GetUser(UserDTO userDto);
    }
}