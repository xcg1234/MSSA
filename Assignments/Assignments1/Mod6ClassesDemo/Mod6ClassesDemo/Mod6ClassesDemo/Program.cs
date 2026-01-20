namespace Mod6ClassesDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee();
            employee.FirstName = "John";
            employee.HourlyRate = 20.0f;
            employee.HoursWorked = 40;

            employee.Salary = employee.CalculatePay();


        }
    }
}
