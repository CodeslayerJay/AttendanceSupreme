using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceSupreme.Engine.Entities
{
    public class TimeLog : EntityBase
    {
        public int UserId { get; set; }
        public int TypeId { get; set; }
        public int? OverriddenById { get; set; }
        public DateTime TimePunched { get; set; } = DateTime.Now;
        public bool Override { get; set; }
        
        
        public virtual User OverriddenBy { get; set; }
        public virtual User User { get; set; }
        public virtual TimeLogType Type { get; set; }
    }
}
