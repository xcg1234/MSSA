namespace Assignment5_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        // can plant flower or not
        public static bool CanPlaceFlowers(int[] bed, int n)
        {
            int res = 0;
            for (int i = 0; i < bed.Length; i++)
            {
                if (bed[i] == 0)
                {
                    if ((i == 0 || bed[i - 1] == 0) && (i == bed.Length - 1 || bed[i + 1] == 0))
                    {
                        res++;
                        bed[i] = 1;
                    }
                }
            }
            return res >= n;

        }
        // climb stairs 
        public static int ClimbStairs(int n)
        {
            if (n <= 2) return n;
            int a = 0, b = 1;
            for (int i = 1; i <= n; i++)
            {
                int temp = a + b;
                a = b;
                b = temp;
            }
            return b;
        }
    }
}
