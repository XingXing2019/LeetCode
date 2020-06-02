//A[i] + A[j] + i - j可以转化成(A[i] + i) + (A[j] - j)。那么这道题就变成了寻找某个位置的值加上index与其之后某个位置的值减去index的最大值。
//创建一个数组记录每个位置在其后面值减index能达到的最大值。
//遍历A，计算当前位置的值加上index再加上其之后位置中值减index能达到的最大值。
using System;


namespace BestSightseeingPair
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = { 1, 2 };
            Console.WriteLine(MaxScoreSightseeingPair(A));
        }
        static int MaxScoreSightseeingPair(int[] A)
        {
            int[] record = new int[A.Length];
            for (int i = 0; i < A.Length; i++)
                record[i] = A[i] - i;
            int[] maxRecord = new int[A.Length];

            int maxDownMinusUp = record[A.Length - 1];
            maxRecord[A.Length - 1] = 0;
            for (int i = A.Length-2; i >= 0; i--)
            {
                maxDownMinusUp = Math.Max(record[i + 1], maxDownMinusUp);
                maxRecord[i] = maxDownMinusUp;
            }
            int res = int.MinValue;
            for (int i = 0; i < A.Length - 1; i++)
            {
                int maxDownPlusUp = A[i] + i;
                res = Math.Max(maxDownPlusUp + maxRecord[i], res);
            }
            return res;
        }
    }
}
