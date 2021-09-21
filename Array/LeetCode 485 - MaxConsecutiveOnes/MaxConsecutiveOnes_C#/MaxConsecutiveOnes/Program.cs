//创建count记录连续1的个数，创建max记录最大连续1的个数。
//遍历nums，如果当前数字为1，则令count加一。否则令max等于max和当前count中较大的一个。
//遍历结束后需再让max等于max和当前count中较大的一个。因为有可能最后一个数字为1，那么最后的到的count还为被比较。
using System;

namespace MaxConsecutiveOnes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int FindMaxConsecutiveOnes(int[] nums)
        {
            int count = 0;
            int max = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 1)
                    count++;
                else
                {
                    max = Math.Max(count, max);
                    count = 0;
                }
            }
            max = Math.Max(count, max);
            return max;
        }
    }
}
