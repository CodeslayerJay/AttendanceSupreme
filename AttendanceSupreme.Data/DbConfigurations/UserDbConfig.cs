using AttendanceSupreme.Engine.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceSupreme.Data.DbConfigurations
{
    internal static class UserDbConfig
    {
        public static void Configure(ModelBuilder builder)
        {
            if (builder != null)
            {
                var _builder = builder.Entity<User>();

                _builder.Property(x => x.FirstName)
                    .HasMaxLength(30)
                    .IsRequired(true);

                _builder.Property(x => x.LastName)
                    .HasMaxLength(30)
                    .IsRequired(true);

                _builder.Property(x => x.LastFourSSN)
                    .HasMaxLength(4)
                    .IsRequired(true);

                _builder.Property(x => x.AccessCode)
                    .HasMaxLength(10)
                    .IsRequired(true);

                _builder.Property(x => x.Password)
                    .IsRequired(true);

                _builder.HasMany("Departments")
                    .WithOne("User");

                _builder.HasMany("Roles")
                    .WithOne("User");

            }
        }
    }
}
