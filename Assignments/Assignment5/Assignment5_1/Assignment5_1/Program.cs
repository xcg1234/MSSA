namespace Assignment5_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IntegerPalindrome(121));
            Console.WriteLine(IntegerPalindrome(-121));
            Console.WriteLine(SumOfDigits(1234));
            Console.WriteLine(ContainsDuplicate(new int[] { 1, 2, 3, 4 }));
            Console.WriteLine(ContainsDuplicate(new int[] { 1, 2, 3, 1 }));
        }

        //check if integer is palindrome
        public static bool IntegerPalindrome(int x)
        {
            if (x < 0) return false; // negative numbers are not palindrome
            int original = x;
            int reversed = 0;
            while (x > 0)
            {
                int digit = x % 10; // get last digit
                reversed = reversed * 10 + digit; // append digit to reversed number
                x /= 10; // remove last digit
            }
            return original == reversed; // check if original and reversed are the same

        }

        //calculate the sum of individual digits of an integer
        public static int SumOfDigits(int x)
        {
            int sum = 0;
            while (x > 0)
            {
                sum += x % 10; // add last digit to sum
                x /= 10; // remove last digit
            }
            return sum;
        }
        //test if any integer apprears at least twice in an array
        public static bool ContainsDuplicate(int[] nums)
        {
            HashSet<int> seen = new HashSet<int>();
            foreach (int num in nums)
            {
                if (seen.Contains(num))
                {
                    return true; // duplicate found
                }
                seen.Add(num); // add number to set
            }
            return false; // no duplicates found
        }
    }
}
