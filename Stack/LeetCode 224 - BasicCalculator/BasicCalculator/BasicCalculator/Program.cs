using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace BasicCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = " 2-1 + 2 ";
            Console.WriteLine(Calculate(s));
        }
        public static int Calculate(string s)
        {
            s += '@';
            var num = "";
            var nums = new Stack<int>();
            var operators = new Stack<char>();
            foreach (var l in s)
            {
                if (l == ' ') continue;
                if (char.IsDigit(l))
                    num += l;
                else
                {
                    if (num != "") nums.Push(int.Parse(num));
                    num = "";
                    if (l == ')')
                    {
                        int temp = 0;
                        while (operators.Count != 0 && operators.Peek() != '(')
                            temp += operators.Pop() == '-' ? -nums.Pop() : nums.Pop();
                        temp += nums.Pop();
                        operators.Pop();
                        nums.Push(temp);
                    }
                    else if (l != '@')
                        operators.Push(l);
                }
            }
            int res = 0;
            while (nums.Count != 0)
                res += operators.Count == 0 || operators.Pop() == '+' ? nums.Pop() : -nums.Pop();
            return res;
        }
    }
}
