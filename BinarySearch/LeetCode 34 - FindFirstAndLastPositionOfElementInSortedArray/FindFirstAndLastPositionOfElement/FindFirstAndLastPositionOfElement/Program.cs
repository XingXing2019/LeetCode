//创建res数组接收结果，长度为2，初始值设为-1。创建left和right指针指向数组头和尾。
//在left <= right的条件下遍历数组，如果res的两个元素分别为left和right的时候停止遍历。
//如果left指向的元素与target相等就将left存入res，否则让left向右移动一位(由于数组是排好序的，如果当前left指向的元素不等于target，则只有向右移才有可能找到target)。
//如果right指向元素与target相等就将right存入res，否则让right向左移动一位(理由同上)。
//最后返回res
using System;

namespace FindFirstAndLastPositionOfElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 5, 7, 7, 8, 8, 10 };
            int target = 8;
            Console.WriteLine(SearchRange(nums, target));
        }
        static int[] SearchRange(int[] nums, int target)
        {
            int[] res = { -1, -1 };
            int left = 0;
            int right = nums.Length - 1;
            while (left <= right)
            {
                if (res[0] == left && res[1] == right)
                    break;
                if (nums[left] == target)
                    res[0] = left;
                else
                    left++;
                if (nums[right] == target)
                    res[1] = right;
                else
                    right--;
            }
            return res;
        }
    }
}
