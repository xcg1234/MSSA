using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment4_3
{
    internal static class ArrayFrequenceCounter
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

            CountAndDisplayFrequency(array);
        }

        private static void CountAndDisplayFrequency(int[] array)
        {
            Dictionary<int, int> frequencyMap = new Dictionary<int, int>();
            List<int> processedOrder = new List<int>();

            foreach (int element in array)
            {
                if (frequencyMap.ContainsKey(element))
                {
                    frequencyMap[element]++;
                }
                else
                {
                    frequencyMap[element] = 1;
                    processedOrder.Add(element);
                }
            }

            Console.WriteLine("\nFrequency of all elements of array:");
            foreach (int element in processedOrder)
            {
                Console.WriteLine($"{element} occurs {frequencyMap[element]} times");
            }
        }
    }
}
