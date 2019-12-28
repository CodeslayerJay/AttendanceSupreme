using AttendanceSupreme.Engine.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceSupreme.Data.DbConfigurations
{
    internal static class RoleDbConfig
    {
        public static void Configure(ModelBuilder builder)
        {
            if (builder != null)
            {
                var _builder = builder.Entity<Role>();

                _builder.Property(x => x.Name)
                    .HasMaxLength(30)
                    .IsRequired(true);
            }
        }
    }
}
