namespace Assignment1._2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Using ReadLine to let user pick which function to execute
            while (true)
            {
                Console.WriteLine("Pick a function to execute:");
                Console.WriteLine("1. Check if two integers are equal");
                Console.WriteLine("2. Find the sum of first n natural numbers");
                Console.WriteLine("3. Calculator");
                Console.WriteLine(
                    "4. Exit");
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        IsEqual();
                        break;
                    case "2":
                        FindSum();

                        break;
                    case "3":
                        Calculator();
                        break;
                    case "4":
                        Console.WriteLine("Exiting the program.");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }

        }

        //accept two integers and check whether they are equal or not.
        private static bool IsEqual()

        {
            int a, b;
            Console.WriteLine("Enter the first integer:");
            string? input1 = Console.ReadLine();
            Console.WriteLine("Enter the second integer:");
            string? input2 = Console.ReadLine();
            //verify if the inputs are valid integers
            if (int.TryParse(input1, out a) && int.TryParse(input2, out b))
            {
                bool result = a == b;
                Console.WriteLine($"The integers are {(result ? "equal" : "not equal")}.");
                return result;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter valid integers.");
                return false;
            }
        }

        private static int FindSum()
        {
            int n;

            Console.WriteLine("Enter a positive integer:");
            string? input = Console.ReadLine();
            if (int.TryParse(input, out n) && n > 0)
            {
                int sum = 0;
                for (int i = 1; i <= n; i++)
                {
                    sum += i;
                }
                Console.WriteLine($"The sum of first {n} natural numbers is: {sum}");
                return sum;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a positive integer.");
                return -1; // Return -1 to indicate an error
            }
        }

        //function 3:Write a menu driven application to perform calculation functions like addition,
        //subtraction, multiplication, and division. Call them appropriately when user selects the option.
        //Give the user the option to continue or exit the program.

        private static void Calculator()
        {
            while (true)
            {
                Console.WriteLine("Pick an option");
                Console.WriteLine("1. Addition");
                Console.WriteLine("2. Subtraction");
                Console.WriteLine("3. Multiplication");
                Console.WriteLine("4. Division");
                Console.WriteLine("5. Exit");
                string? choice = Console.ReadLine();
                if (choice == "5")
                {
                    Console.WriteLine("Exiting the program.");
                    break;
                }
                Console.WriteLine("Enter the first number:");
                string? input1 = Console.ReadLine();
                Console.WriteLine("Enter the second number:");
                string? input2 = Console.ReadLine();
                if (double.TryParse(input1, out double num1) && double.TryParse(input2, out double num2))
                {
                    switch (choice)
                    {
                        case "1":
                            Console.WriteLine($"Result: {num1 + num2}");
                            break;
                        case "2":
                            Console.WriteLine($"Result: {num1 - num2}");
                            break;
                        case "3":
                            Console.WriteLine($"Result: {num1 * num2}");
                            break;
                        case "4":
                            if (num2 != 0)
                            {
                                Console.WriteLine($"Result: {num1 / num2}");
                            }
                            else
                            {
                                Console.WriteLine("Cannot divide by zero.");
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please select a valid operation.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Exit");
                    break;
                }


            }

        }
    }
}
