using AttendanceSupreme.Data;
using AttendanceSupreme.Engine.Entities;
using AttendanceSupreme.Services.DTOs;
using AttendanceSupreme.Services.ValidationSpecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AttendanceSupreme.Services
{
    public class UserService : IUserService
    {
        private readonly ASDataContext _dbContext;
        private readonly AppSecurity _appSecurity;

        public UserService(ASDataContext dbContext)
        {
            _dbContext = dbContext;
            _appSecurity = new AppSecurity();
        }

        // Create User
        public ValidationResult CreateUser(UserDTO userDTO)
        {
            var user = new User
            {
                FirstName = userDTO.Firstname,
                LastFourSSN = userDTO.LastFourSSN,
                LastName = userDTO.Lastname,
                AccessCode = GenerateAccessCode(userDTO.Firstname, userDTO.Lastname, userDTO.LastFourSSN)
            };


            var validatedUserResult = UserSpecs.ValidateUser(user);

            if (validatedUserResult.IsValid)
            {
                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();
            }

            return validatedUserResult;
        }

        // Delete User (Make Inactive)

        // Lookup User by first, last name or ssn
        public User GetUser(string firstname, string lastname, int? lastFourSSN = null)
        {
            var user = (from u in _dbContext.Users
                        where (u.FirstName.Contains(firstname) || String.IsNullOrEmpty(firstname))
                        || (u.LastName.Contains(lastname) || String.IsNullOrEmpty(lastname))
                        || (lastFourSSN.HasValue ? u.LastFourSSN == lastFourSSN.Value : false)
                        select u).FirstOrDefault();

            return user;
        }

        // Get User
        public User GetUser(int userId)
        {
            var user = _dbContext.Users.Where(x => x.Id == userId).FirstOrDefault();

            return user;
        }

        public User GetUser(UserDTO userDto)
        {
            if (userDto.Id > 0)
                return GetUser(userDto.Id);

            return GetUser(userDto.Firstname, userDto.Lastname, userDto.LastFourSSN);
        }

        private string GenerateAccessCode(string firstname, string lastname, int lastFourSSN)
        {
            if (String.IsNullOrEmpty(firstname) || String.IsNullOrEmpty(lastname) || lastFourSSN == 0)
                throw new ArgumentNullException("Firstname, Lastname, and LastFourSSN required.");

            var partOne = firstname.ToLower().Substring(0, 1);
            var partTwo = lastFourSSN.ToString().Substring(0, 3);

            var code = partOne + partTwo + lastFourSSN.ToString();
            
            return code;
        }
    }
}
