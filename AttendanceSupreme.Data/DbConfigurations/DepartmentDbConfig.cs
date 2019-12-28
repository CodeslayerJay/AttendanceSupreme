using AttendanceSupreme.Engine.Entities;
using Microsoft.EntityFrameworkCore;

namespace AttendanceSupreme.Data.DbConfigurations
{
    internal  static class DepartmentDbConfig
    {
        
        public static void Configure(ModelBuilder builder)
        {
            if(builder != null)
            {
                var _builder = builder.Entity<Department>();

                _builder.Property(x => x.Name)
                    .HasMaxLength(30)
                    .IsRequired(true);
            }
        }

    }
}
