using System;
using System.Collections.Generic;

namespace MinimumStringLength
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int MinLength(string s)
        {
            var stack = new Stack<char>();
            foreach (var l in s)
            {
                if (stack.Count != 0 && (l == 'B' && stack.Peek() == 'A' || l == 'D' && stack.Peek() == 'C'))
                    stack.Pop();
                else
                    stack.Push(l);
            }

            return stack.Count;
        }
    }
}
