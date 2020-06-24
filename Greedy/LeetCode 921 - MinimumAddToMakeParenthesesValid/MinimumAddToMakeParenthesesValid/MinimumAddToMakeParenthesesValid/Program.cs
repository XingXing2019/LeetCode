//创建leftCount和rightCount分别代表没有配对的'('和')'的个数。
//遍历字符串，如果当前字符为'('，则使leftCount加一。
//如果当前字符为')'，则需判断当前'('的数量是否足够与之配对。如果当前'('数量为0，则使rightCount加一。
//如果当前'('不为0，则消耗一个'('与')'配对，使leftCount减一。
//最后返回未配对的'('与')'之和。
using System;
using System.Collections.Generic;

namespace MinimumAddToMakeParenthesesValid
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int MinAddToMakeValid_Greedy(string S)
        {
            int leftCount = 0;
            int rightCount = 0;
            for (int i = 0; i < S.Length; i++)
            {
                if(S[i] == '(')
                {
                    leftCount++;
                }
                else if (S[i] == ')')
                {
                    if (leftCount == 0)
                        rightCount++;
                    else
                        leftCount--;
                }
            }
            return leftCount + rightCount;
        }

        static int MinAddToMakeValid_Stack(string S)
        {
            var stack = new Stack<char>();
            foreach (var c in S)
            {
                if (c == ')' && stack.Count != 0 && stack.Peek() == '(')
                    stack.Pop();
                else
                    stack.Push(c);
            }
            return stack.Count;
        }
    }
}
