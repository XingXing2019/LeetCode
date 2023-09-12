using System;
using System.Collections.Generic;
using System.Linq;

namespace MinimumDeletions
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = "aaabbbcceeeeffffgggg";
            Console.WriteLine(MinDeletions(s));
        }
        static int MinDeletions(string s)
        {
            var record = new int[26];
            var max = 0;
            foreach (var letter in s)
            {
                record[letter - 'a']++;
                max = Math.Max(max, record[letter - 'a']);
            }
            var frequency = new int[max + 1];
            var candidates = new Stack<int>();
            for (int i = 0; i < record.Length; i++)
            {
                if(record[i] == 0) continue;
                frequency[record[i]]++;
            }
            var res = 0;
            for (int i = 1; i < frequency.Length; i++)
            {
                if(frequency[i] == 0)
                    candidates.Push(i);
                else if(frequency[i] != 1)
                {
                    for (int j = 0; j < frequency[i] - 1; j++)
                        res += candidates.Count == 0 ? i : i - candidates.Pop();
                }
            }
            return res;
        }
    }
}
