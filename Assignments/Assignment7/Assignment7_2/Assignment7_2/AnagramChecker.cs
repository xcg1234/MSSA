using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment7_2
{
    internal class AnagramChecker
    {
        public static bool AreAnagrams(string s1, string s2) {
            // assuming all strings aare lowercase and no space

            if (s1.Length != s2.Length) {
                return false;
            }
            Dictionary<char, int> commonDictionary = new Dictionary<char, int>();
            for (int i = 0; i < s1.Length; i++) {
                char c1Char = s1[i];
                char c2Char = s2[i];
                if (commonDictionary.ContainsKey(c1Char)) {
                    commonDictionary[c1Char]++;
                } else {
                    commonDictionary[c1Char] = 1;
                }
                
                if (commonDictionary.ContainsKey(c2Char)) {
                    commonDictionary[c2Char]--;
                } else {
                    commonDictionary[c2Char] = -1;
                }


            }
            foreach (var kvp in commonDictionary) {
                if (kvp.Value != 0) {
                    return false;
                }
            }
            return true;
        }
    }
}
