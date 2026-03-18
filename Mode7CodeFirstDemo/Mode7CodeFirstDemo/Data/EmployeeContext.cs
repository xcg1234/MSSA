using Microsoft.EntityFrameworkCore;
using Mode7CodeFirstDemo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mode7CodeFirstDemo.Data
{   //represent the DB
    internal class EmployeeContext:DbContext
    {
        public DbSet<Employee> Employees { get; set; } // table for Employee

        public DbSet<Department> Departments { get; set; } // table for Department

      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=MSI;Initial Catalog=Mode7CodeFirstDemoDb;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
        }

        //data seeding
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 1, DepartmentName = "HR", Location = "New York" },
                new Department { DepartmentId = 2, DepartmentName = "IT", Location = "San Francisco" },
                new Department { DepartmentId = 3, DepartmentName = "Finance", Location = "Chicago" }

            );
            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmployeeId = 1, EmployeeName = "Alice", Salary = 60000, DepartmentId = 1 },
                new Employee { EmployeeId = 2, EmployeeName = "Bob", Salary = 80000, DepartmentId = 2 },
                new Employee { EmployeeId = 3, EmployeeName = "Charlie", Salary = 75000, DepartmentId = 2 }
            );
        }
    }
}
