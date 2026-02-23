using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment7_1
{
    internal class MergeStringAlternatively
    {
        public static string MergeAlternately(string word1, string word2)
        {
            StringBuilder merged = new StringBuilder();
            int maxLength = Math.Max(word1.Length, word2.Length);
            for (int i = 0; i < maxLength; i++)
            {
                if (i < word1.Length)
                {
                    merged.Append(word1[i]);
                }
                if (i < word2.Length)
                {
                    merged.Append(word2[i]);
                }
            }
            return merged.ToString();
        }
    }
}
