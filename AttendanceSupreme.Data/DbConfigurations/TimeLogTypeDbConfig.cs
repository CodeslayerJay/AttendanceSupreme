using AttendanceSupreme.Engine.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceSupreme.Data.DbConfigurations
{
    internal static class TimeLogTypeDbConfig
    {
        public static void Configure(ModelBuilder builder)
        {
            if (builder != null)
            {
                var _builder = builder.Entity<TimeLogType>();

                _builder.Property(x => x.Type)
                    .HasMaxLength(30)
                    .IsRequired(true);

            }
        }
    }
}
