using System;

namespace LargestSubstring
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int MaxLengthBetweenEqualCharacters(string s)
        {
            var record = new int[26];
            for (int i = 0; i < record.Length; i++)
                record[i] = -1;
            var max = -1;
            for (int i = 0; i < s.Length; i++)
            {
                if (record[s[i] - 'a'] == -1)
                    record[s[i] - 'a'] = i;
                else
                    max = Math.Max(max, i - record[s[i] - 'a'] - 1);
            }
            return max;
        }
    }
}
