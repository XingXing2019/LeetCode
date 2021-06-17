using System;
using System.Linq;

namespace NumberOfSubarraysWithBoundedMaximum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = { 7, 3, 6, 7, 1 };
            int L = 1, R = 4;
            Console.WriteLine(NumSubarrayBoundedMax(A, L, R));
        }
        static int NumSubarrayBoundedMax(int[] A, int L, int R)
        {
            var dp = new int[A.Length];
            var pre = -1;
            for (int i = 0; i < dp.Length; i++)
            {
                if (A[i] < L && i > 0)
                    dp[i] = dp[i - 1];
                else if (L <= A[i] && A[i] <= R)
                    dp[i] = i - pre;
                else if (A[i] > R)
                {
                    dp[i] = 0;
                    pre = i;
                }
            }
            return dp.Sum();
        }
    }
}
