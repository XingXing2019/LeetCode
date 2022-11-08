using System;
using System.Collections.Generic;

namespace MakeTheStringGreat
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static string MakeGood(string s)
        {
            var stack = new Stack<char>();
            foreach (var letter in s)
            {
                if (stack.Count != 0 && Math.Abs(stack.Peek() - letter) == 32)
                    stack.Pop();
                else
                    stack.Push(letter);
            }
            var res = "";
            while (stack.Count != 0)
                res = stack.Pop() + res;
            return res;
        }
    }
}
