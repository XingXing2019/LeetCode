using System;

namespace TwoSumLessThanK
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int TwoSumLessThanK(int[] A, int K)
        {
            int res = -1;
            for (int i = 0; i < A.Length; i++)
            {
                for (int j = i + 1; j < A.Length; j++)
                {
                    if (A[i] + A[j] < K)
                        res = Math.Max(res, A[i] + A[j]);
                }
            }
            return res;
        }
    }
}
