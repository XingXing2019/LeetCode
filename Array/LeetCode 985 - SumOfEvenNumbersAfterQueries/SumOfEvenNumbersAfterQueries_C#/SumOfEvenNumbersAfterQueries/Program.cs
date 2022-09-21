//创建evenSum记录原始数组中偶数的和。遍历数组，按照queries要求操作evenSum，将每次得结果记入res。
using System;

namespace SumOfEvenNumbersAfterQueries
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int[] SumEvenAfterQueries(int[] A, int[][] queries)
        {
            int evenSum = 0;
            foreach (var num in A)
                if (num % 2 == 0)
                    evenSum += num;
            int[] res = new int[queries.Length];
            for (int i = 0; i < queries.Length; i++)
            {
                if ((A[queries[i][1]] + queries[i][0]) % 2 == 0)
                {
                    if (A[queries[i][1]] % 2 == 0)
                        evenSum += queries[i][0];
                    else
                        evenSum += A[queries[i][1]] + queries[i][0];
                }
                else
                {
                    if (A[queries[i][1]] % 2 == 0)
                        evenSum -= A[queries[i][1]];
                }
                A[queries[i][1]] += queries[i][0];
                res[i] = evenSum;
            }
            return res;
        }
    }
}
