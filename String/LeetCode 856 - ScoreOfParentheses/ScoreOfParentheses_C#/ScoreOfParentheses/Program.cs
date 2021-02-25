//创建times记录得分应该加倍的结果。创建res记录最后得分。
//遍历字符串，如果当前字符为'('，则让times乘以2。
//如果当前字符为')'并且其前一字符为'('，则他们可以配成括号对，此时将times除以2，并让res加上当前的times(其实是times * 1，1为得分)。
//如果当前字符为')'并且其前一字符不为'('，则证明此')'会和之前的一个'('配成括号对，并且该括号对在此刻的加倍效果已经结束，其后面的括号不再受此括号对的影响。所以让times除以2。
//遍历结束后返回res。
using System;

namespace ScoreOfParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int ScoreOfParentheses(string S)
        {
            int times = 1;
            int res = 0;
            for (int i = 0; i < S.Length; i++)
            {
                if (S[i] == '(')
                    times *= 2;
                else if (S[i] == ')' && S[i - 1] == '(')
                {
                    times /= 2;
                    res += times;
                }
                else if (S[i] == ')' && S[i] != '(')
                    times /= 2;
            }
            return res;
        }
    }
}
