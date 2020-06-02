//创建动态数组dp记录每个数字的结果(1 - N)。长度设为N + 1。将dp[1]设为false。
//从i = 2开始遍历数组。如果当前位置的前一位置(dp[i - 1])为true，则dp[i]为false。因为Alice先选择1，则下一轮轮到Bob选择。那么Bob是否能赢由dp[i - 1]决定。
//不用考虑Alice会选择比1大的数字。因为i - 1位置的结果也是由他前面位置的结果所决定的。所以i - 1位置的结果已经考虑了Alice选择比1大的数字的情况。
//如果当前位置的前一位置(dp[i - 1])为false，则dp[i]为true。理由同上。
//最后返回dp[N]。
using System;

namespace DivisorGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static bool DivisorGame(int N)
        {
            bool[] dp = new bool[N + 1];
            dp[1] = false;
            for (int i = 2; i < dp.Length; i++)
            {
                if (dp[i - 1] == true)
                    dp[i] = false;
                else
                    dp[i] = true;
            }
            return dp[N];
        }
    }
}
