namespace Week3ChallengeLabs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing Palindrome with sample of 'eye' ");
            Console.WriteLine(isPalindrome("eye")); // true
            Console.WriteLine();

            Console.WriteLine("Testing Sum of Digits in String with sample of 'a1b2c3' ");
            Console.WriteLine(sumOfDigitsInString("a1b2c3\n")); // 6
            
            Console.WriteLine("Testing Two Sum with sample of [2,7,11,15] and target of 9 ");
            Console.WriteLine(string.Join(", ", twoSum(new int[] { 2, 7, 11, 15 }, 9))); // [0,1]

            Console.WriteLine();

            Console.WriteLine("Testing Removing AB or CD with sample of 'ABCDAB' ");
            Console.WriteLine(removingABorCD("ABCDAB")); // 0
        }

        static bool isPalindrome(string str)
        {
            int left = 0;
            int right = str.Length - 1;
            while (left < right)
            {
                if (str[left] != str[right])
                {
                    return false;
                }
                left++;
                right--;
            }
            return true;
        }

        static int sumOfDigitsInString(string str) {
            int res = 0;
            foreach (char c in str) {
                if (char.IsDigit(c)) {
                    res += c - '0';
                }
            }
            return res;
        }

        //two sum
        static int[] twoSum(int[] nums, int target) { 
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++) { 
                int complement = target - nums[i];
                if (map.ContainsKey(complement)) {
                    return new int[] { map[complement], i };
                }
                map[nums[i]] = i;
            }
            // since there is exactly one solution, we not reach here

            return [];
        }

        static int removingABorCD(string str) { 
            if (string.IsNullOrEmpty(str)) {
                return 0;
            }
            Stack<char> stack = new Stack<char>();
            foreach (char c in str)
            {
                if (stack.Count > 0 && stack.Peek() == 'A' && c == 'B')
                {
                    stack.Pop();
                }
                else if (stack.Count > 0 && stack.Peek() == 'C' && c == 'D')
                {
                    stack.Pop();
                }
                else
                {
                    stack.Push(c);
                }
            }

            return stack.Count;
        }
    }
}
