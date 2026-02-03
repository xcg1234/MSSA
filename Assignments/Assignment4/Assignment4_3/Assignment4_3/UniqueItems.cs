using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment4_3
{
    internal static class UniqueItems
    {
        public static void Run()
        {
            Console.Write("Input the number of elements to be stored in the array: ");
            int n = int.Parse(Console.ReadLine());

            int[] array = new int[n];

            Console.WriteLine($"Input {n} elements in the array:");
            for (int i = 0; i < n; i++)
            {
                Console.Write($"element - {i}: ");
                array[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine();
            DisplayUniqueItems(array);
        }

        private static void DisplayUniqueItems(int[] array)
        {
            Dictionary<int, int> itemCount = new Dictionary<int, int>();
            foreach (var item in array)
            {
                if (itemCount.ContainsKey(item))
                {
                    itemCount[item]++;
                }
                else
                {
                    itemCount[item] = 1;
                }
            }

            List<int> uniqueItems = new List<int>();
            foreach (var key in itemCount.Keys)
            {
                if (itemCount[key] == 1)
                {
                    uniqueItems.Add(key);
                }
            }

            if (uniqueItems.Count == 0)
            {
                Console.WriteLine("No unique items found in the array.");
            }
            else if (uniqueItems.Count == 1)
            {
                Console.WriteLine($"The unique item in this array is: {uniqueItems[0]}");
            }
            else
            {
                Console.WriteLine("The unique items in this array are:");
                foreach (var item in uniqueItems)
                {
                    Console.WriteLine($"  {item}");
                }
            }
        }
    }
}
