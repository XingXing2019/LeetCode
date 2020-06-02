//二分搜索0到target之间的数字。每次计算中值mid。并统计如果替换数组中比中值大的数字所得之和。如果等于target则返回mid。如果小于则移动li，否则移动hi.
//搜索结束后如果里不等于hi，则返回其中较小值。
//否则统计比li小1的值与li哪个更符合条件。
using System;

namespace SumOfMutatedArrayClosestToTarget
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 4, 9, 3 };
            int target = 10;
            Console.WriteLine(FindBestValue(arr, target));
        }
        static int FindBestValue(int[] arr, int target)
        {
            int li = 0;
            int hi = target;
            while (li < hi)
            {
                int mid = li + (hi - li) / 2;
                int tem = 0;
                foreach (var n in arr)
                    tem += Math.Min(mid, n);
                if (tem == target)
                    return mid;
                else if (tem < target)
                    li = mid + 1;
                else
                    hi = mid;
            }
            if(li != hi)
                return Math.Min(li, hi);
            int minusOne = li - 1;
            int minusOneSum = 0, sum = 0;
            foreach (var n in arr)
            {
                minusOneSum += Math.Min(minusOne, n);
                sum += Math.Min(li, n);
            }
            int minAbs = Math.Min(Math.Abs(minusOneSum - target), Math.Abs(sum - target));
            if (minAbs == Math.Abs(minusOneSum - target))
                return li - 1;
            else
                return li;
        }
    }
}
