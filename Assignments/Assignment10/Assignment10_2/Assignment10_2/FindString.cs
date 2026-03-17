using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment10_2
{
    internal class FindString
    {
        //// find a string that starts and ends with a specific char
        public static string FindStringWithChar(List<string> strings, char startChar, char endChar)
        {
            var result = from s in strings
                         where s.StartsWith(startChar) && s.EndsWith(endChar)
                         select s;
            return result.FirstOrDefault();
        }
    }
}
