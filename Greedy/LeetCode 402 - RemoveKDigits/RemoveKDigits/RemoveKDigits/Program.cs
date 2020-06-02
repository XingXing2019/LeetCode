//利用栈存储数字。遍历字符串，当栈不为空，当前数字小于栈顶数字并且k大于0时，将栈顶弹出，k减一。
//如果当前数字不为零或者栈不为空时，将数字压入栈。
//当栈不为空且k大于0时，将栈顶弹出，k减一。
//将栈中数字接到字符串中，检查字符串，如为空则返回0，否则返回字符串。
using System;
using System.Collections;
using System.Collections.Generic;

namespace RemoveKDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            string num = "1432219";
            Console.WriteLine(RemoveKdigits(num, 3));
        }
        static string RemoveKdigits(string num, int k)
        {
            var stack = new Stack<char>();
            var res = "";
            foreach (var digit in num)
            {
                while (stack.Count != 0 && digit < stack.Peek() && k > 0)
                {
                    stack.Pop();
                    k--;
                }   
                if(stack.Count != 0 || digit != '0')
                    stack.Push(digit);
            }
            while (stack.Count != 0 && k > 0)
            {
                stack.Pop();
                k--;
            }
            foreach (var digit in stack)
                res = digit + res;
            return res == "" ? "0" : res;
        }
    }
}
