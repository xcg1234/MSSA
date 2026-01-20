
namespace Assignment1
{
    internal class Program
    {
        private static void Main()
        {
            while (true)
            {
                Console.WriteLine("\nPlease select an option:");
                Console.WriteLine("1. Store and print personal details");
                Console.WriteLine("2. Sum of two numbers");
                Console.WriteLine("3. Divide two numbers");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice (1-4): ");

                string? choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        HandlePersonalDetails();
                        break;
                    case "2":
                        HandleSumOfTwoNumbers();
                        break;
                    case "3":
                        HandleDivision();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private static void HandlePersonalDetails()
        {
            string name;
            int age;
            string address;

            // Get user input for personal details
            Console.Write("Enter your name: ");
            name = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Name cannot be empty. Please enter a valid name.");
                return;
            }
            Console.Write("Enter your age: ");
            string? ageInput = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(ageInput))
            {
                Console.WriteLine("Age input cannot be empty. Please enter a valid age.");
                return;
            }
            if (!int.TryParse(ageInput, out age) || age < 0)
            {
                Console.WriteLine("Please enter a valid numeric age.");
                return;
            }
            Console.Write("Enter your address: ");
            string addressINput = Console.ReadLine() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(addressINput))
            {
                Console.WriteLine("Address cannot be empty. Please enter a valid address.");
                return;
            }
            if ((!string.IsNullOrEmpty(addressINput) && addressINput.Length < 2)
                // or the address is pure numbers which is not allowed
                || int.TryParse(addressINput, out _))
            {
                Console.WriteLine("Address seems too short or the address is pure number. Please enter a valid address.");
                return;
            }
            address = addressINput;
            // Print personal details on console screen
            Console.WriteLine("\nPersonal Details:");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Age: {age}");
            Console.WriteLine($"Address: {address}");
        }

        private static void HandleSumOfTwoNumbers()
        {
            Console.Write("Enter first number: ");
            string? input = Console.ReadLine();
            if (!int.TryParse(input, out int num1))
            {
                Console.WriteLine("Invalid input!");
                return;
            }
            Console.Write("Enter second number: ");
            string? input2 = Console.ReadLine();
            if (!int.TryParse(input2, out int num2))
            {
                Console.WriteLine("Invalid input!");
                return;
            }
            int sum = num1 + num2;
            Console.WriteLine("The sum of {0} and {1} is: {2}", num1, num2, sum);
        }

        private static void HandleDivision()
        {
            double num1, num2, result, remainder;
            Console.Write("Enter first number: ");
            string? input = Console.ReadLine();
            if (!double.TryParse(input, out num1))
            {
                Console.WriteLine("Invalid input!");
                return;
            }
            // Second number input from console, validate it and store as num2
            Console.Write("Enter second number: ");
            string? input2 = Console.ReadLine();
            if (!double.TryParse(input2, out num2))
            {
                Console.WriteLine("Invalid input!");
                return;
            }
            if (num2 == 0)
            {
                Console.WriteLine("Error: Cannot divide by zero.");
                return;
            }
            // Calculate result and remainder using double to support decimals
            result = num1 / num2;
            remainder = num1 % num2;
            // Print the results
            Console.WriteLine("The result of {0} divided by {1} is: {2}", num1, num2, result);
            Console.WriteLine("The remainder of {0} divided by {1} is: {2}", num1, num2, remainder);
        }
    }
}
