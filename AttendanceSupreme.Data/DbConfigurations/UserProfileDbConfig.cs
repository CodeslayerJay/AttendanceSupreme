using AttendanceSupreme.Engine.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceSupreme.Data.DbConfigurations
{
    internal static class UserProfileDbConfig
    {
        public static void Configure(ModelBuilder builder)
        {
            if (builder != null)
            {
                var _builder = builder.Entity<UserProfile>();

                _builder.Property(x => x.Address1)
                    .HasMaxLength(30)
                    .IsRequired(false);

                _builder.Property(x => x.Address2)
                    .HasMaxLength(30)
                    .IsRequired(false);

                _builder.Property(x => x.City)
                    .HasMaxLength(30)
                    .IsRequired(false);

                _builder.Property(x => x.State)
                    .HasMaxLength(30)
                    .IsRequired(false);

                _builder.Property(x => x.Country)
                    .HasMaxLength(30)
                    .IsRequired(false);

                _builder.Property(x => x.Phone)
                    .HasMaxLength(10)
                    .IsRequired(false);

                _builder.Property(x => x.SecondaryPhone)
                    .HasMaxLength(10)
                    .IsRequired(false);

                _builder.Property(x => x.Email)
                    .HasMaxLength(30)
                    .IsRequired(false);

            }
        }
    }
}
