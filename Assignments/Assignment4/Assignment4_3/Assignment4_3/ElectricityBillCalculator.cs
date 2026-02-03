using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment4_3
{
    internal static class ElectricityBillCalculator
    {
        public static void Run()
        {
            Console.WriteLine("===== Electricity Bill Calculator =====");
            Console.WriteLine();

            Console.Write("Enter Customer ID: ");
            string customerID = Console.ReadLine();

            Console.Write("Enter Customer Name: ");
            string customerName = Console.ReadLine();

            Console.Write("Enter Units Consumed: ");
            double unitConsumed = double.Parse(Console.ReadLine());

            Console.WriteLine();
            double totalBill = CalculateBill(customerID, customerName, unitConsumed);

            Console.WriteLine("========================================");
            Console.WriteLine($"Total Amount to Pay: ${totalBill:F2}");
            Console.WriteLine("========================================");
        }

        private static double CalculateBill(string customerID, string customerName, double unitConsumed)
        {
            double billAmount = 0.0;
            if (unitConsumed <= 199)
            {
                billAmount = unitConsumed * 1.2;
            }
            else if (unitConsumed < 400)
            {
                billAmount = unitConsumed * 1.5;
            }
            else if (unitConsumed < 600)
            {
                billAmount = unitConsumed * 1.8;
            }
            else if (unitConsumed >= 600)
            {
                billAmount = unitConsumed * 2.0;
            }

            if (billAmount > 400)
            {
                billAmount += billAmount * 0.15; // 15% surcharge
            }

            Console.WriteLine($"Customer ID          : {customerID}");
            Console.WriteLine($"Customer Name        : {customerName}");
            Console.WriteLine($"Units Consumed       : {unitConsumed}");

            return billAmount;
        }
    }
}
