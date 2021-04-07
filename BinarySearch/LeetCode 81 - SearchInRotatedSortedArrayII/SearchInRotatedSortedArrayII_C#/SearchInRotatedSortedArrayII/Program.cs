//创建left和right指针，分别指向数组头和尾。创建bool型res，初始值设为false。
//从数组的左右两端向中间遍历数组。如果left或者right指针指向数字与target相等，则将res设为true，并停止遍历。
//应为数组是排序好的，如果left指向的数字与target更近则让left移动。否则让right移动。
//遍历结束后，返回res。
using System;

namespace SearchInRotatedSortedArrayII
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static bool Search(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;
            bool res = false;
            while (left <= right)
            {
                if(nums[left] == target)
                {
                    res = true;
                    break;
                }
                else if (nums[right] == target)
                {
                    res = true;
                    break;
                }
                if (Math.Abs(nums[left] - target) < Math.Abs(nums[right] - target))
                    left++;
                else
                    right--;    
            }
            return res;
        }
    }
}
