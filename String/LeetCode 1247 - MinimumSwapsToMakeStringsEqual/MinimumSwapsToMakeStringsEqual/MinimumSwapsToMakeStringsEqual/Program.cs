using System;
using System.Collections.Generic;
using System.Text;

namespace MinimumSwapsToMakeStringsEqual
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "xyxyxy", s2 = "yxyxyx";
            Console.WriteLine(MinimumSwap(s1, s2));
        }
        static int MinimumSwap(string s1, string s2)
        {
            if (s1.Length != s2.Length) return -1;
            var stack = new Stack<char>();
            var res = 0;
            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] != s2[i])
                {
                    if (stack.Count != 0 && s1[i] == stack.Peek())
                    {
                        res++;
                        stack.Pop();
                    }
                    else
                        stack.Push(s1[i]);
                }
            }
            if (stack.Count == 0) return res;
            if (stack.Count % 2 != 0) return -1;
            return res + 2 * (stack.Count / 4) + stack.Count % 4;
        }
    }
}
