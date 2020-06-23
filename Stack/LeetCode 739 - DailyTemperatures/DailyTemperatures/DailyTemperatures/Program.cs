//使用单调栈，将T中每个数字的index压栈。在当前数字比栈顶大的时候就一直弹栈，并记录结果。
//暴力求解，不会超时，但速度很慢。
using System;
using System.Collections;
using System.Collections.Generic;

namespace DailyTemperatures
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] T = { 73, 74, 75, 71, 69, 72, 76, 73 };
            DailyTemperatures(T);
        }
        static int[] DailyTemperatures_MonoStack(int[] T)
        {
            int[] res = new int[T.Length];
            var stack = new Stack<int>();
            for (int i = 0; i < T.Length; i++)
            {
                while (stack.Count != 0 && T[stack.Peek()] < T[i])
                {
                    var index = stack.Pop();
                    res[index] = i - index;
                }
                stack.Push(i);
            }
            return res;
        }

        static int[] DailyTemperatures_BruteForce(int[] T)
        {
            int[] res = new int[T.Length];
            for (int i = 0; i < T.Length; i++)
            {
                for (int j = i + 1; j < T.Length; j++)
                {
                    if (T[j] > T[i])
                    {
                        res[i] = j - i;
                        break;
                    }
                }
            }
            return res;
        }
    }
}
