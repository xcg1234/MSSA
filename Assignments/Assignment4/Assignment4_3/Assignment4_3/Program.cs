using System;

namespace Assignment4_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===== Assignment 4.3 =====");
            Console.WriteLine("1. Electricity Bill Calculator");
            Console.WriteLine("2. Array Frequency Counter");
            Console.WriteLine("3. Unique Items Finder");
            Console.Write("\nSelect an option (1-3): ");
            
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    ElectricityBillCalculator.Run();
                    break;
                case "2":
                    ArrayFrequenceCounter.Run();
                    break;
                case "3":
                    UniqueItems.Run();
                    break;
                default:
                    Console.WriteLine("Invalid option selected.");
                    break;
            }
        }
    }
}
