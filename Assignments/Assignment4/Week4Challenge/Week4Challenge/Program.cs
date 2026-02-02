namespace Week4Challenge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Week 4 Challenge!");
            Console.WriteLine(ContainsDigitThree(7201432));
            Console.WriteLine(ContainsDigitThree(87510));

            Console.WriteLine("==========>");
            Console.WriteLine(DivideByTwoOrThree(15, 30)); // should return 450
            Console.WriteLine(DivideByTwoOrThree(2, 90)); // should return 180
            Console.WriteLine(DivideByTwoOrThree(7, 12)); // should return 19

            Console.WriteLine("==========>");

            char[] arr = { 'H', 'e', 'l', 'l', 'o' };
            ReverseCharArray(arr);
            Console.WriteLine(arr); // should print "olleH"

        }

        static bool ContainsDigitThree(int number)
        {
            while (number > 0)
            {
                int digit = number % 10;
                if (digit == 3)
                {
                    return true;
                }
                number /= 10;
            }
            return false;
        }

        static int DivideByTwoOrThree(int num1, int num2)
        {
            if ((num1 % 2 == 0 && num2 % 2 == 0) || (num1 % 3 ==0 && num2 % 3 == 0))
            {
                return num1 * num2;
            }
            else
            {
                return num1 + num2;
            }

        }

        //reverse char array in place
        static void ReverseCharArray(char[] arr)
        {
            int left = 0;
            int right = arr.Length - 1;
            while (left < right)
            {
                char temp = arr[left];
                arr[left] = arr[right];
                arr[right] = temp;
                left++;
                right--;
            }
        }
    }
}
