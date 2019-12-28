using System.Collections.Generic;

namespace AttendanceSupreme.Engine.Entities
{
    public class Role : EntityBase
    {
        public Role()
        {
            Users = new HashSet<UserRole>();
        }

        public string Name { get; set; }

        public virtual ICollection<UserRole> Users { get; set; }
    }
}