//li和hi分别设为1和nums中最大的数字，然后在li和hi之间进行二分搜索，每次计算sum，以求找出最小可能的被除数。
using System;
using System.Linq;

namespace FindTheSmallestDivisorGivenAThreshold
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 19 };
            int threshold = 5;
            Console.WriteLine(SmallestDivisor(nums, threshold));
        }
        static int SmallestDivisor(int[] nums, int threshold)
        {
            int li = 1, hi = nums.Max(n => n);
            while (li < hi)
            {
                int mid = li + (hi - li) / 2;
                int sum = CalcSum(nums, mid);
                if (sum > threshold)
                    li = mid + 1;
                else
                    hi = mid;
            }
            return li;
        }
        static int CalcSum(int[] nums, int divisor)
        {
            int sum = 0;
            foreach (var n in nums)
                sum += n % divisor == 0 ? n / divisor : n / divisor + 1;
            return sum;
        }
    }
}
