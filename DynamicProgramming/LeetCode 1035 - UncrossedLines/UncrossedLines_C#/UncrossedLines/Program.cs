//动态规划找出每个以A[i]和B[j]结尾的子串中有多少个一样的数字。
using System;

namespace UncrossedLines
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = { 1,1,2,1,2 };
            int[] B = {1,3,2,3,1};
            Console.WriteLine(MaxUncrossedLines(A, B));
        }
        static int MaxUncrossedLines(int[] A, int[] B)
        {
            int[][] dp = new int[A.Length][];
            for (int i = 0; i < dp.Length; i++)
                dp[i] = new int[B.Length];
            dp[0][0] = A[0] == B[0] ? 1 : 0;
            for (int i = 1; i < dp.Length; i++)
            {
                if (A[i] != B[0])
                    dp[i][0] = dp[i - 1][0];
                else
                    dp[i][0] = 1;
            }
            for (int i = 1; i < dp[0].Length; i++)
            {
                if (A[0] != B[i])
                    dp[0][i] = dp[0][i - 1];
                else
                    dp[0][i] = 1;
            }
            for (int i = 1; i < dp.Length; i++)
            {
                for (int j = 1; j < dp[0].Length; j++)
                {
                    if (A[i] == B[j])
                        dp[i][j] = dp[i - 1][j - 1] + 1;
                    else
                        dp[i][j] = Math.Max(dp[i - 1][j], dp[i][j - 1]);
                }
            }
            return dp[A.Length - 1][B.Length - 1];   
        }
    }
}
