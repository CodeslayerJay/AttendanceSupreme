using AttendanceSupreme.Data.DbConfigurations;
using AttendanceSupreme.Engine.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceSupreme.Data
{
    public class ASDataContext : DbContext
    {
        public ASDataContext(DbContextOptions<ASDataContext> options) :base(options)
        { }

        private readonly string _connString = "Server=(localdb)\\MSSQLLocalDB;Database=AttendaceSupremeDb;Trusted_Connection=true; MultipleActiveResultSets=true";

        public ASDataContext()
        { }


        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<SchedulePreference> SchedulePreferences { get; set; }
        public virtual DbSet<TimeLog> TimeLogs { get; set; }
        public virtual DbSet<TimeLogType> TimeLogTypes { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }
        public virtual DbSet<ScheduledTime> ScheduledTimes { get; set; }
        public virtual DbSet<PreferredDay> UserPreferredDays { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer(_connString);
            }
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            DbConfig.Init(builder);
            DbConfig.Configure();

            base.OnModelCreating(builder);
        }
    }
}
