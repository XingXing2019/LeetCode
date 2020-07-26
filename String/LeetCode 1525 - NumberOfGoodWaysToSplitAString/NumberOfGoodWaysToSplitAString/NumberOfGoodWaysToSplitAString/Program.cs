using System;
using System.Collections.Generic;

namespace NumberOfGoodWaysToSplitAString
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "a";
            Console.WriteLine(NumSplits(s));
        }
        static int NumSplits(string s)
        {
            var right  = new Dictionary<char, int>();
            var left = new Dictionary<char, int>();
            var res = 0;
            foreach (var letter in s)
            {
                if (!right.ContainsKey(letter))
                    right[letter] = 1;
                else
                    right[letter]++;
            }
            foreach (var letter in s)
            {
                if (!left.ContainsKey(letter))
                    left[letter] = 1;
                else
                    left[letter]++;
                if (right.ContainsKey(letter))
                    right[letter]--;
                if (right[letter] == 0)
                    right.Remove(letter);
                if (left.Count == right.Count)
                    res++;
            }
            return res;
        }
    }
}
