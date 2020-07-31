using System;

namespace TwoSumLessThanK
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int TwoSumLessThanK_BruteForce(int[] A, int K)
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

        static int TwoSumLessThanK_Sort(int[] A, int K)
        {
            int res = -1;
            int li = 0, hi = A.Length - 1;
            Array.Sort(A);
            while (li < hi)
            {
                if (A[li] + A[hi] < K)
                {
                    res = Math.Max(res, A[li] + A[hi]);
                    li++;
                }
                else
                    hi--;
            }
            return res;
        }
    }
}
