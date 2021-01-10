using System;
using System.Collections.Generic;

namespace MaximumScoreFromRemovingSubstrings
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int MaximumGain(string s, int x, int y)
        {
            string larger = x > y ? "ab" : "ba", smaller = x > y ? "ba" : "ab";
            List<char> stack1 = new List<char>(), stack2 = new List<char>();
            var res = 0;
            foreach (var letter in s)
            {
                if (stack1.Count == 0 || letter != 'a' && letter != 'b' || stack1[^1].ToString() + letter != larger)
                    stack1.Add(letter);
                else
                {
                    res += Math.Max(x, y);
                    stack1.RemoveAt(stack1.Count - 1);
                }
            }
            foreach (var letter in stack1)
            {
                if (stack2.Count == 0 || letter != 'a' && letter != 'b' || stack2[^1].ToString() + letter != smaller)
                    stack2.Add(letter);
                else
                {
                    res += Math.Min(x, y);
                    stack2.RemoveAt(stack2.Count - 1);
                }
            }
            return res;
        }
    }
}
