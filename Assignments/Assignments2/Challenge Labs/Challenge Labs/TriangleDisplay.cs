using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge_Labs
{
    internal class TriangleDisplay
    {
        public static void DisplayTriangle(int num, int width)
        {
            
            for (int i = width; i >= 1; i--)
            {
                for (int j = 1; j <= i; j++)
                {
                    
                    Console.Write(num);
                }
                Console.WriteLine();
            }
        }
    }
}
