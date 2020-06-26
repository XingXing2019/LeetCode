//按照逆波兰表达式定义做就好
using System;
using System.Collections.Generic;

namespace EvaluateReversePolishNotation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tokens = { "10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+" };
            Console.WriteLine(EvalRPN(tokens));
        }
        static int EvalRPN(string[] tokens)
        {
            var stack = new Stack<int>();
            foreach (var token in tokens)
            {
                if(token != "+" && token != "-" && token != "*" && token != "/")
                    stack.Push(int.Parse(token));
                else
                {
                    int num1 = stack.Pop();
                    int num2 = stack.Pop();
                    if(token == "+")
                        stack.Push(num2 + num1);
                    else if (token == "-")
                        stack.Push(num2 - num1);
                    else if (token == "*")
                        stack.Push(num2 * num1);
                    else
                        stack.Push(num2 / num1);
                }
            }
            return stack.Peek();
        }
    }
}
