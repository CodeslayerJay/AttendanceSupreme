using AttendanceSupreme.Engine.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceSupreme.Engine.Entities
{
    public class UserDept
    {
        public int UserId { get; set; }
        public int DeptId { get; set; }

        public virtual User User { get; set; }
        public virtual Department Department { get; set; }
    }
}
