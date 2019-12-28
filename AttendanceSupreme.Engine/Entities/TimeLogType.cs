using System.Collections.Generic;

namespace AttendanceSupreme.Engine.Entities
{
    public class TimeLogType : EntityBase
    {
        public TimeLogType()
        {
            TimeLogs = new HashSet<TimeLog>();
        }
        public string Type { get; set; }
        public virtual ICollection<TimeLog> TimeLogs { get; set; }
    }
}