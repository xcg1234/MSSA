using Microsoft.EntityFrameworkCore;
using Mode7CodeFirstDemo.Data;

namespace Mode7CodeFirstDemo
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Records.Context = new EmployeeContext();
            
            Records.Context.Database.EnsureCreated(); // create db if not exists
            Records.Context.Departments.Load();
            Records.Context.Employees.Load();
            Application.Run(new Form1());
        }
    }
}