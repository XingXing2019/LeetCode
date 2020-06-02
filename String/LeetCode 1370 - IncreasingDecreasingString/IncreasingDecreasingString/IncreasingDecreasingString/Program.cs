using System;

namespace IncreasingDecreasingString
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "leetcode";
            Console.WriteLine(SortString(s));
        }
        static string SortString(string s)
        {
            var record = new int[26];
            for (int i = 0; i < s.Length; i++)
                record[s[i] - 'a']++;
            var res = "";
            while (res.Length < s.Length)
            {
                for (int i = 0; i < record.Length && res.Length < s.Length; i++)
                {
                    if (record[i] != 0)
                    {
                        res += (char)(i + 97);
                        record[i]--;
                    }
                }
                for (int i = record.Length - 1; i >= 0 && res.Length < s.Length; i--)
                {
                    if (record[i] != 0)
                    {
                        res += (char)(i + 97);
                        record[i]--;
                    }
                }
            }
            return res;
        }
    }
}
