//思路为遍历数组的每一个数，固定住当前数，找出这个数以后的两个数和这个数相加为0。
//先对数组排序，保证后面数不小于前面数。
//创建current代表当前遍历到的数字，初始值设为1.
//遍历数组，如果当前数大于0，则停止循环，后面一定没有数能和他加和为0。如果当前数和上一轮遍历的数字相同，则跳过该次遍历。
//设置left代表当前数下一个数，right代表数组尾端数字。将current设为当前数。
//在left小于right的条件下遍历当前数右面的数组，如果current与left和right指向的数之和为0，则将三个数字计入结果。
//同时在left小于right的条件下，使left向右移动，right向左移动。直到left和right分别指向和之前不同的值。
//如果current与left和right指向的数之和小于0，则使left向右移动找到更大的值。
//如果current与left和right指向的数之和大于0，则使right向左移动找到更小的值。
using System;
using System.Collections.Generic;

namespace _3Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 0, 0, 0 };
            ThreeSum(nums);
        }
        static IList<IList<int>> ThreeSum(int[] nums)
        {
            List<IList<int>> res = new List<IList<int>>();
            Array.Sort(nums);
            int current = 1;
            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (nums[i] > 0)
                    break;
                if (nums[i] == current)
                    continue;
                int left = i + 1;
                int right = nums.Length - 1;
                current = nums[i];
                while (left < right)
                {
                    int leftNum = nums[left];
                    int rightNum = nums[right];
                    int total = current + leftNum + rightNum;
                    if (total == 0)
                    {
                        List<int> tri = new List<int>();
                        tri.Add(current);
                        tri.Add(leftNum);
                        tri.Add(rightNum);
                        while (nums[left] == leftNum && left < right)
                            left++;
                        while (nums[right] == rightNum && left < right)
                            right--;
                        res.Add(tri);
                    }
                    else if (total < 0)
                        left++;
                    else if (total > 0)
                        right--;
                }
            }
            return res;
        }
    }
}
