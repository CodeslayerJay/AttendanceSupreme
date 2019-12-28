using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceSupreme.Engine.Entities
{
    public class User : EntityBase
    {

        public User()
        {
            Departments = new HashSet<UserDept>();
            Roles = new HashSet<UserRole>();
            ScheduledTimes = new HashSet<ScheduledTime>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int LastFourSSN { get; set; }
        public string AccessCode { get; set; }

        public string Password { get; set; }

        public virtual UserProfile Profile { get; set; }
        public virtual ICollection<UserDept> Departments { get; set; }
        public virtual ICollection<UserRole> Roles { get; set; }
        public virtual ICollection<ScheduledTime> ScheduledTimes { get; set; }
    }
}
