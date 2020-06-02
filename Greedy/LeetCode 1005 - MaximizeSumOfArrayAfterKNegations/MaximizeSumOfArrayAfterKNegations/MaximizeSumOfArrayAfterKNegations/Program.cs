//对数组排序，如第一个数为正，检查K的奇偶，如为奇则只需对第一个数取反一次即可。
//如果第一个数为负，则遍历数组，在K范围内将负数取反。
//如果K大于负数个数，则在所有负数取反后，再对数组排序一次然后停止遍历。
//检查K的奇偶，如为奇则只需对第一个数取反一次即可。
using System;

namespace MaximizeSumOfArrayAfterKNegations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = { 4, 2, 3 };
            int K = 1;
            Console.WriteLine(LargestSumAfterKNegations(A, K));
        }
        static int LargestSumAfterKNegations(int[] A, int K)
        {
            Array.Sort(A);
            int index = 0;
            if(A[index] >= 0)
            {
                if (K % 2 != 0)
                    A[0] = -A[0];
            }
            else
            {
                while (K > 0)
                {
                    if (A[index] < 0)
                    {
                        A[index] = -A[index];
                        index++;
                        K--;
                    }
                    else
                    {
                        Array.Sort(A);
                        break;
                    }
                }
                if (K % 2 != 0)
                    A[0] = -A[0];
            }
            int sum = 0;
            for (int i = 0; i < A.Length; i++)
                sum += A[i];
            return sum;
        }
    }
}
