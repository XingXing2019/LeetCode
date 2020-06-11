using System;
using System.Linq;

namespace LongestSubstring
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int LongestSubstring_DivideAndConquer(string s, int k)
        {
            return GetMaxLength(s, k, 0, s.Length - 1);
        }

        private int GetMaxLength(string s, int k, int start, int end)
        {
            if (s == "") return 0;
            int[] record = new int[26];
            for (int i = start; i <= end; i++)
                record[s[i] - 'a']++;
            for (int i = 0; i < record.Length; i++)
            {
                if (record[i] > 0 && record[i] < k)
                {
                    int index = s.IndexOf((char) (i + 'a'), start);
                    return Math.Max(GetMaxLength(s, k, start, index - 1), GetMaxLength(s, k, index + 1, end));
                }
            }
            return end - start + 1;
        }
    }
}
