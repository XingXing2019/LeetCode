using System;

namespace OptimalPartitionOfString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int PartitionString(string s)
        {
            var freq = new int[26];
            var res = 1;
            foreach (var l in s)
            {
                freq[l - 'a']++;
                if (freq[l - 'a'] <= 1) continue;
                res++;
                freq = new int[26];
                freq[l - 'a']++;
            }
            return res;
        }
    }
}
