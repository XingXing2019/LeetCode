//创建两个数组sumsL和sumsM，记录从某个位置开始向前L和M个数字之和。
//创建两个数组maxSumL和maxSumM，记录在某个位置之后M和L个数字能分别组成的最大值。
//遍历sumsL，寻找当前位置和另一个数组中当前位置之后M个位置之后的数字能组成的最大值。
//遍历sumsM，做与之前同样的操作。
using System;

namespace MaximumSumOfTwoNonOverlapping
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = { 2, 1, 5, 6, 0, 9, 5, 0, 3, 8 };
            int L = 4;
            int M = 3;
            Console.WriteLine(MaxSumTwoNoOverlap(A, L, M));
        }
        static int MaxSumTwoNoOverlap(int[] A, int L, int M)
        {
            int[] sumsL = new int[A.Length];
            int[] sumsM = new int[A.Length];
            for (int i = 0; i < L; i++)
                sumsL[L - 1] += A[i];
            for (int i = 0; i < M; i++)
                sumsM[M - 1] += A[i];
            for (int i = L; i < A.Length; i++)
                sumsL[i] = sumsL[i - 1] + A[i] - A[i - L];
            for (int i = M; i < A.Length; i++)
                sumsM[i] = sumsM[i - 1] + A[i] - A[i - M];
            int[] maxSumL = new int[A.Length];
            int[] maxSumM = new int[A.Length];
            int maxL = 0;
            int maxM = 0;
            for (int i = A.Length-1; i >= 0; i--)
            {
                maxL = Math.Max(maxL, sumsL[i]);
                maxSumL[i] = maxL;
                maxM = Math.Max(maxM, sumsM[i]);
                maxSumM[i] = maxM;
            }
            int res = 0;
            for (int i = 0; i < A.Length - M; i++)
                res = Math.Max(res, sumsL[i] + maxSumM[i + M]);
            for (int i = 0; i < A.Length - L; i++)
                res = Math.Max(res, sumsM[i] + maxSumL[i + L]);
            return res;
        }
    }
}
