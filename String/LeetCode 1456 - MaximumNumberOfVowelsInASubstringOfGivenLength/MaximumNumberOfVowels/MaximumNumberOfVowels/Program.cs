using System;
using System.Collections.Generic;

namespace MaximumNumberOfVowels
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "leetcode";
            int k = 3;
            Console.WriteLine(MaxVowels(s, k));
        }
        static int MaxVowels(string s, int k)
        {
            var vowels = new HashSet<char> {'a', 'e', 'i', 'o', 'u'};
            int count = 0;
            for (int i = 0; i < k; i++)
                if (vowels.Contains(s[i]))
                    count++;
            int max = count;
            for (int i = 0; i < s.Length - k; i++)
            {
                if (vowels.Contains(s[i]))
                    count--;
                if (vowels.Contains(s[i + k]))
                    count++;
                max = Math.Max(max, count);
            }
            return max;
        }
    }
}
