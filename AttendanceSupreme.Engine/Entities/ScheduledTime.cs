using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceSupreme.Engine.Entities
{
    public class ScheduledTime : EntityBase
    {
        public int UserId { get; set; }
        public DateTime ScheduledDateTime { get; set; }
        public double ScheduledWork { get; set; }
        public double ScheduledBreak { get; set; }

        public virtual User User { get; set; }
    }
}
