using System;

namespace MaximumSumCircularSubarray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = {1, -2, 3, -2};
            Console.WriteLine(MaxSubarraySumCircular(A));
        }
        static int MaxSubarraySumCircular(int[] A)
        {
            int max = int.MinValue, min = int.MaxValue, sum = 0, curMax = 0, curMin = 0;
            foreach (var num in A)
            {
                curMax = Math.Max(curMax + num, num);
                curMin = Math.Min(curMin + num, num);
                max = Math.Max(max, curMax);
                min = Math.Min(min, curMin);
                sum += num;
            }
            return sum == min ? max : Math.Max(max, sum - min);
        }
    }
}
