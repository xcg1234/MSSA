namespace Assignment10_ChallengeLabs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1
            string s = "abcd";
            string t = "abcde";
            HashSet<char> set = new HashSet<char>(s);
            //find the extra char that in t but not in s
            char extraChar = '\0';
            foreach (char c in t)
            {
                if (!set.Contains(c))
                {
                    extraChar = c;
                    break;
                }
            }
            Console.WriteLine($"The extra char is: {extraChar}");

            //Problem2:
            //Input: nums1 = [1,2,3,0,0,0], m = 3, nums2 = [2,5,6], n = 3

            //Output: [1, 2, 2, 3, 5, 6]
            int[] nums1 = { 1, 2, 3, 0, 0, 0 };
            int m = 3;
            int[] nums2 = { 2, 5, 6 };
            int n = 3;

            int i = m - 1; // pointer for nums1
            int j = n - 1; // pointer for nums2
            int k = m + n - 1; // pointer for merged array

            while (j >= 0)
            {
                if (i >= 0 && nums1[i] > nums2[j])
                {
                    nums1[k--] = nums1[i--];
                }
                else
                {
                    nums1[k--] = nums2[j--];
                }
            }
            Console.WriteLine("Merged array: " + string.Join(", ", nums1));

        }
    }
}
