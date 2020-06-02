using System;

namespace LargestSumOfAverages
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = { 9, 1, 2, 3, 9 };
            int K = 3;
            Console.WriteLine(LargestSumOfAverages(A, K));
        }
        static double LargestSumOfAverages(int[] A, int K)
        {
            double[][] dp = new double[A.Length][];
            for (int i = 0; i < dp.Length; i++)
                dp[i] = new double[2];
            int minMembers = A.Length / K;
            int maxMember = A.Length - K + 1;
            dp[0][0] = A[0];
            dp[0][1] = 1;
            double res = A[1] > A[0] ? 0 : A[0];
            for (int i = 1; i < A.Length; i++)
            {
                if (dp[i - 1][1] + 1 <= maxMember && dp[i - 1][1] + 1 >= minMembers)
                {
                    if(A[i] < A[i - 1])
                    {
                        dp[i][0] = A[i];
                        dp[i][1] = 1;
                    }
                    else
                    {
                        dp[i][0] = (dp[i - 1][0] * dp[i - 1][1] + A[i]) / (dp[i - 1][1] + 1);
                        dp[i][1] = dp[i - 1][1] + 1;
                    }
                }
                else
                {
                    res += dp[i - 1][0];
                    dp[i][0] = A[i];
                    dp[i][1] = 1;
                }
            }
            return res + dp[dp.Length - 1][0];
        }
    }
}
