using AttendanceSupreme.Engine.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceSupreme.Data.DbConfigurations
{
    internal static class SchedulePrefsDbConfig
    {
        public static void Configure(ModelBuilder builder)
        {
            if (builder != null)
            {
                var _builder = builder.Entity<SchedulePreference>();

                _builder.Property(x => x.StartTime)
                    .IsRequired(true);

                _builder.Property(x => x.EndTime)
                    .IsRequired(true);

            }
        }
    }
}
