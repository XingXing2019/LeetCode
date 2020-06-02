//创建even和odd指针，分别指向奇数位和偶数位。
//遍历A，如果当前数字时奇数则存入奇数位，同时令odd进2。否则存入偶数位，并使even进2.
using System;

namespace SortArrayByParityII
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = { 4, 2, 5, 7 };
            Console.WriteLine(SortArrayByParityII(A));
        }
        static int[] SortArrayByParityII(int[] A)
        {
            int[] res = new int[A.Length];
            int even = 0;
            int odd = 1;
            for (int i = 0; i < A.Length; i++)
            {
                if(A[i] % 2 == 0)
                {
                    res[even] = A[i];
                    even += 2;
                }
                else
                {
                    res[odd] = A[i];
                    odd += 2;
                }
            }
            return res;
        }
    }
}
