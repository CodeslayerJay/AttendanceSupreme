using AttendanceSupreme.Engine.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceSupreme.Data.DbConfigurations
{
    internal static class TimeLogDbConfig
    {
        public static void Configure(ModelBuilder builder)
        {
            if (builder != null)
            {
                var _builder = builder.Entity<TimeLog>();

                _builder.Property(x => x.TimePunched)
                    .IsRequired(true);

            }
        }
    }
}
