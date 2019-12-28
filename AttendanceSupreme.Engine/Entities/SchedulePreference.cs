using AttendanceSupreme.Engine.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceSupreme.Engine.Entities
{
    public class SchedulePreference : EntityBase
    {
        public SchedulePreference()
        {
            PreferredDays = new HashSet<PreferredDay>();
        }

        public int UserId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
            
        public virtual User User { get; set; }
        public virtual ICollection<PreferredDay> PreferredDays { get; set; }
    }
}
