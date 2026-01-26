using System.Text;

namespace Assignment3_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintNumbers();
            
            // Testing other functions
            IfYearIsLeap(2024);
            IfYearIsLeapManual(2000);
            CountSpacesInString("Hello World MSSA");
            ChangeFirstTwoOneToZero(new int[] { 0, 1, 1, 1, 0 });
        }

        // print a string of numbers greater than 0 and less than 100
        public static void PrintNumbers()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i < 100; i++)
            {
                if (i % 2 == 0)
                {
                    sb.Append(i).Append(" ");
                }
            }
            Console.WriteLine(sb.ToString().Trim());
        }

        public static void IfYearIsLeap(int year)
        {
            if (DateTime.IsLeapYear(year))
            {
                Console.WriteLine($"{year} is a leap year.");
            }
            else
            {
                Console.WriteLine($"{year} is not a leap year.");
            }
        }
        // or manually implement the logic
        public static void IfYearIsLeapManual(int year)
        {
            if ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0))
            {
                Console.WriteLine($"{year} is a leap year.");
            }
            else
            {
                Console.WriteLine($"{year} is not a leap year.");
            }
        }

        // take an input of string and count the space number in it
        public static void CountSpacesInString(string? input)
        {
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("String is empty or null.");
                return;
            }

            int spaceCount = 0;
            foreach (char c in input)
            {
                if (c == ' ')
                {
                    spaceCount++;
                }
            }
            Console.WriteLine($"Number of spaces in the string: {spaceCount}");

        }


        public static void ChangeFirstTwoOneToZero(int[]? arr) {
            if (arr == null) return;

            for (int i = 0; i < arr.Length - 1; i++) { 
                if (arr[i] == 1 && arr[i+1] == 1) {
                    arr[i] = 0;
                    arr[i+1] = 0;
                    break;
                }
                
            }
            //print the array
            Console.WriteLine("Modified array: " + string.Join(", ", arr));

        }

    }
}













