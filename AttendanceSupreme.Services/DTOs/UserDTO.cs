using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceSupreme.Services.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int LastFourSSN { get; set; }
    }
}
