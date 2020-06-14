//解法一：暴力遍历求解。
//解法二：使用单调栈，维护一个单调栈，里面存储着prices中的index，确保栈顶index对应的价格大于栈底。
//那么如果当前遍历到的价格低于栈顶index对应的价格，那么他一定低于栈中所有index对应的价格。那么就将栈中所有index对应的价格减去当前遍历到的价格。并将剪过的index弹栈。
using System;
using System.Collections.Generic;

namespace FinalPrices
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] price = {8, 4, 6, 2, 3};
            Console.WriteLine(FinalPrices_MonotoneStack(price));
        }
        static int[] FinalPrices_BruteForce(int[] prices)
        {
            for (int i = 0; i < prices.Length; i++)
            {
                for (int j = i + 1; j < prices.Length; j++)
                {
                    if (prices[j] <= prices[i])
                    {
                        prices[i] -= prices[j];
                        break;
                    }
                }
            }
            return prices;
        }

        static int[] FinalPrices_MonotoneStack(int[] prices)
        {
            var stack = new Stack<int>();
            for (int i = 0; i < prices.Length; i++)
            {
                while (stack.Count!= 0 && prices[stack.Peek()] >= prices[i])
                {
                    prices[stack.Peek()] -= prices[i];
                    stack.Pop();
                }
                stack.Push(i);
            }
            return prices;
        }
    }
}
