//维持一个宽度为K的滑窗， 记录滑窗内的数字之和，使其去k * threshold比较。
//滑窗右移，每次更新滑窗内数字之和
using System;

namespace NumberOfSubArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int NumOfSubarrays(int[] arr, int k, int threshold)
        {
            int li = 0, hi = k - 1, res = 0, subSum = 0;
            int sum = k * threshold;
            for (int i = 0; i < k; i++)
                subSum += arr[i];
            while (hi < arr.Length - 1)
            {
                if (subSum >= sum)
                    res++;
                subSum -= arr[li++];
                subSum += arr[++hi];
            }
            if (subSum >= sum)
                res++;
            return res;
        }
    }
}
