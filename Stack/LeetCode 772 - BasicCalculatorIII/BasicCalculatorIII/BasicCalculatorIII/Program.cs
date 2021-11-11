using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicCalculatorIII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var s = "(2+6*3+5-(3*14/7+2)*5)";
            Console.WriteLine(Calculate(s));
        }
        public static int Calculate(string s)
        {
            var stack = new Stack<string>();
            foreach (var l in s)
            {
                if (l == ')')
                {
                    var temp = "";
                    while (stack.Peek() != "(")
                        temp = stack.Pop() + temp;
                    stack.Pop();
                    stack.Push(Calc(temp).ToString());
                }
                else
                    stack.Push(l.ToString());
            }
            var final = "";
            while (stack.Count != 0)
                final = stack.Pop() + final;
            return Calc(final);
        }

        public static int Calc(string s)
        {
            s += "#";
            string opt = "", num = "";
            var stack = new Stack<int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsDigit(s[i]))
                    num += s[i];
                else
                {
                    if (i == 0 || !char.IsDigit(s[i - 1]))
                        num += s[i];
                    else
                    {
                        if (opt == "+" || opt == "")
                            stack.Push(int.Parse(num));
                        else if (opt == "-")
                            stack.Push(-int.Parse(num));
                        else if (opt == "*")
                            stack.Push(stack.Pop() * int.Parse(num));
                        else
                            stack.Push(stack.Pop() / int.Parse(num));
                        num = "";
                        opt = s[i].ToString();
                    }
                }
            }
            return stack.Sum();
        }
    }
}
