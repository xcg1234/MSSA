using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment7_2
{
    internal class ReverseVowelInString
    {
        public static string ReverseVowels(string s) {
            char[] arr = s.ToCharArray();
            int left = 0;
            int right = arr.Length - 1;
            while (left < right) {
                while (left < right && !IsVowel(arr[left])) {
                    left++;
                }
                while (left < right && !IsVowel(arr[right])) {
                    right--;
                }
                if (left < right) {
                    char temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;
                    left++;
                    right--;
                }
            }
            return new string(arr);
        }
        public static bool IsVowel(char c) {
            return "aeiouAEIOU".IndexOf(c) >= 0;
        }
    }
}
