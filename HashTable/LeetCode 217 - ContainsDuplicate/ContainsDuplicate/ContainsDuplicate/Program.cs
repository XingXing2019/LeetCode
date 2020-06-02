//方法一：创建int型HashSet，遍历数组，如果发现当前数字在HashSet中，则返回true。否则遍历结束后返回false。
//方法二：先检查数组长度，如果小于2，则直接返回false。将数组排序，遍历数组，如果发现当前数字等于前一个数字，则返回true。否则在遍历结束后返回false。
using System;
using System.Collections.Generic;

namespace ContainsDuplicate
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static bool ContainsDuplicate(int[] nums)
        {
            if (nums.Length < 2)
                return false;
            Array.Sort(nums);
            for (int i = 1; i < nums.Length; i++)
                if (nums[i] == nums[i - 1])
                    return true;
            return false;
        }
        static bool ContainsDuplicate2(int[] nums)
        {
            var unique = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (unique.Contains(nums[i]))
                    return true;
                else
                    unique.Add(nums[i]);
            }
            return false;
        }
        
    }
}
