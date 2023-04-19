using HRS.Busniess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRS.Data
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Attendance> Attendance { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Leave> Leave { get; set; }
        public DbSet<Salary> Salary { get; set; }

        public DbSet<Designation> Designation { get; set; }

        public DbSet<Approval_Reject_Leave> Approval_Reject_Leave { get; set; }

        public DbSet<Manager> Manager { get; set; }
    }
}
