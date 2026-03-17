namespace Assignment10_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //write linq find the positive number from the list
            List<int> num = new List<int>() { -1, -2, 3, 4, -5, 6 };
            var positiveNum = from n in num
                              where n > 0
                              select n;
            Console.WriteLine("Positive numbers in the list:");
            foreach (var n in positiveNum)
            {
                Console.WriteLine(n);
            }


            //quesiton2. Write a program to create a list of employees.
            //Consider a hard coded list. Display all employees who have salary more than $5000 and age < 30.
            List<Employee> employees = new List<Employee>()
            {
                new Employee { Id = 1, Name = "John", Age = 25, Salary = 6000 },
                new Employee { Id = 2, Name = "Jane", Age = 28, Salary = 4500 },
                new Employee { Id = 3, Name = "Bob", Age = 32, Salary = 7000 },
                new Employee { Id = 4, Name = "Alice", Age = 22, Salary = 5500 },
                new Employee { Id = 5, Name = "Tom", Age = 29, Salary = 4800 }
            };

            var filteredEmployees = from e in employees
                                    where e.Salary > 5000 && e.Age < 30
                                    select e;
            Console.WriteLine("\nEmployees with salary more than $5000 and age less than 30:");
            foreach (var e in filteredEmployees)
            {
                Console.WriteLine($"Id: {e.Id}, Name: {e.Name}, Age: {e.Age}, Salary: {e.Salary}");
            }


            List<string> cities = new List<string>() { "ROME", "LONDON", "NAIROBI", "CALIFORNIA", "ZURICH", "NEW DELHI", "AMSTERDAM", "ABU DHABI", "PARIS" };
            //call FindStringWithChar
            string res = FindString.FindStringWithChar(cities, 'A', 'M');
            Console.WriteLine($"\nFirst string that starts with 'A' and ends with 'M': {res}");

            //create a list of numbers and display numbers greater than 80.
            List<int> numbers = new List<int>() { 45, 67, 89, 23, 90, 12, 78, 99 };
            var greaterThan80 = from n in numbers
                                where n > 80
                                select n;
            Console.WriteLine("\nNumbers greater than 80:");
            foreach (var n in greaterThan80)
            {
                Console.WriteLine(n);

            }
        }
    }
}
