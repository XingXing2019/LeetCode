//遍历数组找出最大值和最小值。如果差值小于2倍K则返回0，否则返回其差值减2倍K
using System;

namespace SmallestRangeI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int SmallestRangeI(int[] A, int K)
        {
            int max = int.MinValue;
            int min = int.MaxValue;
            for (int i = 0; i < A.Length; i++)
            {
                max = Math.Max(max, A[i]);
                min = Math.Min(min, A[i]);
            }
            if (max - min <= 2 * K)
                return 0;
            else
                return (max - K) - (min + K);
        }
    }
}
