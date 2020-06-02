using System;

namespace PreviousPermutationWithOneSwap
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = { 3, 1, 1, 3 };
            Console.WriteLine(PrevPermOpt1(A));
        }
        static int[] PrevPermOpt1(int[] A)
        {
            for (int i = A.Length - 2; i >= 0; i--)
            {
                if (A[i] > A[i + 1])
                {
                    int swapPos = i + 1;
                    int max = 0;
                    for (int j = i + 1; j < A.Length; j++)
                    {
                        if(A[j] > max && A[j] < A[i]) 
                        {
                            swapPos = j;
                            max = A[j];
                        }
                    }
                    int tem = A[swapPos];
                    A[swapPos] = A[i];
                    A[i] = tem;
                    return A;
                }
            }
            return A;
        }
    }
}
