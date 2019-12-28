using AttendanceSupreme.Engine.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceSupreme.Data.DbConfigurations
{
    internal static class DbConfig
    {
        private static ModelBuilder _builder;

        public static void Init(ModelBuilder builder)
        {
            _builder = builder;
        }

        public static void Configure()
        {
            if(_builder != null)
            {
                ConfigureDepartment();
                ConfigureRole();
                ConfigureTimeLogType();
                ConfigureUser();
                ConfigureSchedulePrefs();
                ConfigureUserProfile();
                ConfigureTimeLog();
                ConfigureMisc();
            }
        }

        private static void ConfigureMisc()
        {
            _builder.Entity<UserRole>()
                .HasKey(x => new { x.UserId, x.RoleId });

            _builder.Entity<UserRole>()
                .HasOne(x => x.User)
                .WithMany(x => x.Roles)
                .HasForeignKey(x => x.UserId);

            _builder.Entity<UserRole>()
                .HasOne(x => x.Role)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.RoleId);

            _builder.Entity<UserDept>()
                .HasKey(x => new { x.UserId, x.DeptId });

            _builder.Entity<UserDept>()
                .HasOne(x => x.User)
                .WithMany(x => x.Departments)
                .HasForeignKey(x => x.UserId);

            _builder.Entity<UserDept>()
                .HasOne(x => x.Department)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.DeptId);

        }

        private static void ConfigureTimeLog()
        {
            TimeLogDbConfig.Configure(_builder);
        }

        private static void ConfigureUserProfile()
        {
            UserProfileDbConfig.Configure(_builder);
        }

        private static void ConfigureSchedulePrefs()
        {
            SchedulePrefsDbConfig.Configure(_builder);
        }

        private static void ConfigureDepartment()
        {
            DepartmentDbConfig.Configure(_builder);
        }
        private static void ConfigureRole()
        {
            RoleDbConfig.Configure(_builder);
        }

        private static void ConfigureTimeLogType()
        {
            TimeLogTypeDbConfig.Configure(_builder);
        }
        private static void ConfigureUser()
        {
            UserDbConfig.Configure(_builder);
        }

    }
}
