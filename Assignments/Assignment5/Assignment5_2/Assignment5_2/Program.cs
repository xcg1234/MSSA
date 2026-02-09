namespace Assignment5_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //test the functions below
            Console.WriteLine(LengthOfTheLastWord("Hello World")); // should return 5
            Console.WriteLine(LengthOfTheLastWord("   fly me   to   the moon  ")); // should return 4
            PrintNaturalNumbers(5); // should print 1 2 3 4 5
            Console.WriteLine("\n");  // backslash, not forward slash
            PrintNaturalNumbersDescending(5); // should print 5 4 3 2 1
            Console.WriteLine("\n");  // backslash, not forward slash
            Console.WriteLine(IsPalindrome("racecar")); // should return true
        }

        //return the length of the last word in the given string
        public static int LengthOfTheLastWord(string s)
        {
            if (s.Length == 0) return 0;
            s = s.TrimEnd();
            int res = 0;
            int right = s.Length - 1;
            while (right >= 0 && s[right] != ' ')
            {
                res++;
                right--;
            }
            return res;
        }

        //return first n natrual number using recursion starting from 1

        public static void PrintNaturalNumbers(int n)
        {
            if (n <= 0) return;
            PrintNaturalNumbers(n - 1);
            Console.Write(n + " ");


        }

        // same, but starting from n and going down to 1
        public static void PrintNaturalNumbersDescending(int n)
        {
            if (n <= 0) return;
            Console.Write(n + " ");
            PrintNaturalNumbersDescending(n - 1);
        }

        //check string is palindrome or not using recursion
        public static bool IsPalindrome(string s)
        {
            if (s.Length <= 1) return true;
            if (s[0] != s[s.Length - 1]) return false;
            return IsPalindrome(s.Substring(1, s.Length - 2));
        }
    }
}
