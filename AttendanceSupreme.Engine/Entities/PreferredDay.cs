using AttendanceSupreme.Engine.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceSupreme.Engine.Entities
{
    public class PreferredDay : EntityBase
    {
        public int UserId { get; set; }
        public DaysOfWeek Day { get; set; }

        public virtual User User { get; set; }
    }
}
