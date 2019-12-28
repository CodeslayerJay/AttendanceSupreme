using System.Collections.Generic;

namespace AttendanceSupreme.Engine.Entities
{
    public class Department : EntityBase
    {
        public Department()
        {
            Users = new HashSet<UserDept>();
        }

        public string Name { get; set; }
        public int OwnerId { get; set; }

        public User Owner { get; set; }
        public virtual ICollection<UserDept> Users { get; set; }
    }
}