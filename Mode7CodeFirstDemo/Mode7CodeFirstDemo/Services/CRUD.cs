using Mode7CodeFirstDemo.Data; // Add this if 'Records' is defined in this namespace
using Mode7CodeFirstDemo.Models; // Add this if 'Employee' and 'Department' are defined in this namespace
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mode7CodeFirstDemo.Services
{
    public class CRUD
    {
        public void AddEmployee(Employee employee)
        {
            Records.Context.Employees.Add(employee);
            Records.Context.SaveChanges();// save to db
        }
        public List<Employee> GetAllEmployees()
        {
            return Records.Context.Employees.ToList();
        }
        public List<Department> GetAllDepartments()
        {
            return Records.Context.Departments.ToList();
        }
        public Employee? GetEmployee(int id)
        {

            return Records.Context.Employees.Find(id);


        }
        public void DeleteEmployee(int id)
        {
            var emp = Records.Context.Employees.Find(id);
            if (emp != null)
            {
                Records.Context.Employees.Remove(emp);
                Records.Context.SaveChanges();
            }
        }
        public void UpdateEmployee(int id, Employee emp)
        {
            var existingemp = Records.Context.Employees.Find(id);
            if (existingemp != null)
            {
                existingemp.EmployeeName = emp.EmployeeName;
                existingemp.Salary = emp.Salary;
                existingemp.DepartmentId = emp.DepartmentId;
                Records.Context.SaveChanges();
            }

        }

    }
}
