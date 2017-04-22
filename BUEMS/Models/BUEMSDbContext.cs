using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BUEMS.Models
{
    public class BUEMSDbContext : DbContext
    {
        public DbSet<Tax> Taxes { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Allowance> Allowances { get; set; }
    }
}