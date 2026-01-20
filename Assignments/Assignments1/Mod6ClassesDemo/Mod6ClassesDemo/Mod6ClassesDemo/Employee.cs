namespace Mod6ClassesDemo
{
    internal class Employee
    {
        static int count = 0;
        public Employee()
        {
            count++;
            this.id = count;
        }
        int id;
        public int Id
        {
            get { return id; }
        }

        public string FirstName { get; set; }
        public float HourlyRate { get; set; }
        public int HoursWorked { get; set; }

        private decimal salary;

        public decimal Salary
        {
            get { return salary; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Salary cannot be negative.");
                }
                salary = value;
            }
        }

        private void Deductions() { 
            this.HourlyRate *= 0.8f;
        }

        public decimal CalculatePay()
        {
            Deductions();
            return (decimal)(HourlyRate * HoursWorked);
        }
    }
}
