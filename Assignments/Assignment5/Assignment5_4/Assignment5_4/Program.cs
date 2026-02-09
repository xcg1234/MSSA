namespace Assignment5_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Test PrintDigits function
            Console.WriteLine("Enter a number to print its digits:");
            int number = int.Parse(Console.ReadLine());
            Console.Write("Digits: ");
            PrintDigits(number);
            Console.WriteLine("\n");

            // Test SumRightDiagonal function
            Console.WriteLine("Enter the size of the square matrix:");
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];

            Console.WriteLine("Enter the matrix elements:");
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write($"Element [{i},{j}]: ");
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }

            int sum = SumRightDiagonal(matrix);
            Console.WriteLine($"\nSum of right diagonal: {sum}");
        }
        //function to print digits of number using recursion
        public static void PrintDigits(int number)
        {
            if (number == 0)
            {
                return;
            }
            int digit = number % 10;
            PrintDigits(number / 10);
            Console.Write(digit + " ");
        }

        //function to return the sum of numbers in right diagonal of matrix
        public static int SumRightDiagonal(int[,] matrix)
        {
            int res = 0;
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i++) {
                res += matrix[i, cols - i - 1];
            }
            return res;

        }
    }
}
