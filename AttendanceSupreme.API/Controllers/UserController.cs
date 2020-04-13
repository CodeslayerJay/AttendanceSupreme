using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AttendanceSupreme.Engine.Entities;
using AttendanceSupreme.Services;
using AttendanceSupreme.Services.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AttendanceSupreme.API.Controllers
{
    public class UserController : BaseApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        public IActionResult CreateUser(UserDTO userDto)
        {
            var user = _userService.GetUser(userDto);

            if (user != null)
                return BadRequest("User already exists.");

            var result = _userService.CreateUser(userDto);

            return Ok(result);

        }
    }
}