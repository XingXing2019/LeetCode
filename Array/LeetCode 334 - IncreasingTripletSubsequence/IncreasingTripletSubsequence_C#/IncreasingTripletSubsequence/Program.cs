//遍历数组记录最小值和第二小值。遍历前将两个值设为int最大值。
//遍历中如果当前数字大于第二小值，证明有三个数字递增，则返回true。
//如果当前数字小于最小值，则更新最小值。如果当前数字在最小值和第二小值之间则更新第二小值。
//需要特别注意，只有在当前数字在最小值和第二小值之间的时候才更新第二小值。否则会出现相同的最小值和第二小值的情况。
using System;

namespace IncreasingTripletSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = {1, 1, -2, 6};
            Console.WriteLine(IncreasingTriplet(nums));
        }
        static bool IncreasingTriplet(int[] nums)
        {
            int firstMin = int.MaxValue, secondMin = int.MaxValue;
            foreach (var num in nums)
            {
                if (num > secondMin) return true;
                if (num < firstMin)
                    firstMin = num;
                else if (num < secondMin && num > firstMin)
                    secondMin = num;
            }
            return false;
        }
    }
}
