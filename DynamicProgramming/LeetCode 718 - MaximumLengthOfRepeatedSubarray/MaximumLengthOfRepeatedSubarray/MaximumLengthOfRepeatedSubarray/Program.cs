using System;

namespace MaximumLengthOfRepeatedSubarray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = { 1, 0, 0, 0, 1 };
            int[] B = { 1, 0, 0, 1, 1 };
            Console.WriteLine(FindLength(A, B));
        }
        static int FindLength(int[] A, int[] B)
        {
            int[,] dp = new int[A.Length + 1, B.Length + 1];
            int max = 0;
            for (int i = 1; i <= A.Length; i++)
            {
                for (int j = 1; j <= B.Length; j++)
                {
                    dp[i, j] = A[i - 1] == B[j - 1] ? dp[i - 1, j - 1] + 1 : 0;
                    max = Math.Max(max, dp[i, j]);
                }
            }
            return max;
        }
    }
}
