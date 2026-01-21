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

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}