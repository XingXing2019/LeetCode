using System;
using System.Collections.Generic;
using System.Text;

namespace UsingARobotToPrint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public string RobotWithString(string s)
        {
            var minAfter = new int[s.Length];
            int min = s[^1];
            for (int i = s.Length - 1; i >= 0; i--)
            {
                min = Math.Min(min, s[i]);
                minAfter[i] = min;
            }
            var res = new StringBuilder();
            var stack = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                while (stack.Count != 0 && stack.Peek() <= minAfter[i])
                    res.Append(stack.Pop());
                stack.Push(s[i]);
            }
            while (stack.Count != 0)
                res.Append(stack.Pop());
            return res.ToString();
        }
    }
}
