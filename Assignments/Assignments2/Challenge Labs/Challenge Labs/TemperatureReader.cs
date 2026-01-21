using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace Challenge_Labs
{
    internal class TemperatureReader
    {
        public static void ReadTemperature()
        {
            Console.WriteLine("Enter the temperature in Fahrenheit:");
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int temperature))
            {
                //using switch expression
                string message = temperature switch
                {
                    <= 10 => "Freezing weather",
                    <= 20 => "Very Cold weather",
                    <= 35 => "Cold weather",
                    <= 50 => "Normal in Weather",
                    <= 65 => "It's Hot",
                    _ => "It's Very Hot"
                };
                Console.WriteLine(message);
            }
            else
            {
                Console.WriteLine("Invalid temperature input.");
            }
        }
    }
}
