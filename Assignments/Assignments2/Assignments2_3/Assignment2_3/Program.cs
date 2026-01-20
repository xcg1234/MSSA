//1. Write a console application to create a text file and save your basic details like name, age, address ( use dummy data). Read the details from same file and print on console.

using System;
using System.IO;
class Program
{
    static void Main(string[] args)
    {
        string filePath = "UserDetails.txt";

        // Dummy data
        string name = "John Doe";
        int age = 30;
        string address = "123 Main St, Anytown, USA";

        // Write details to file
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine("Name: " + name);
            writer.WriteLine("Age: " + age);
            writer.WriteLine("Address: " + address);
        }

        // Read details from file and print to console
        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }

        Console.WriteLine("Following demostration is for the tip calculator:");

        //ask user for bill amount
        Console.Write("Enter the bill amount: ");
        string? billInput = Console.ReadLine();
        //sanitize the input to make sure it's number not characters
        if (!decimal.TryParse(billInput, out decimal billAmount))
        {
            Console.WriteLine("Invalid bill amount. Please enter a valid number.");
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
            return;
        }
        //ask user for tip percentage
        Console.Write("Enter the tip percentage: ");
        string? tipInput = Console.ReadLine();
        //sanitize the input to make sure it's number not characters
        if (!decimal.TryParse(tipInput, out decimal tipPercentage))
        {
            Console.WriteLine("Invalid tip percentage. Please enter a valid number.");
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
            return;
        }
        //create an instance of TipCalculator
        TipCalculator tipCalculator = new TipCalculator(billAmount, tipPercentage);
        try
        {
            decimal tipAmount = tipCalculator.CalculateTip();
            Console.WriteLine($"The tip amount is: {tipAmount:C}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}