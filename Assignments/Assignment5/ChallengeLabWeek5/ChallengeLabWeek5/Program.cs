namespace ChallengeLabWeek5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine(SingleElement(new int[] { 4,1,2,1,2 }));
            Console.WriteLine(FindMissingNumber(new int[] { 9, 6, 4, 2, 3, 5, 7, 0, 1 }));
        }

        public static int SingleElement(int[] nums)
        {
            int res = 0;
            foreach (int num in nums)
            {
                res ^= num;
            }
            return res;
        }

        public static int FindMissingNumber(int[] nums) { 
            int n = nums.Length;
            int goodSum = n * (n + 1) / 2;
            return goodSum - nums.Sum();
        }
    }

}
