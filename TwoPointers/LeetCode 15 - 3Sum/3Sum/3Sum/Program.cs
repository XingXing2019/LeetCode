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
            int[] nums = { 1, -2, -3, 4, 1, 3, 0, 3, -2, 1, -2, 2, -1, 1, -5, 4, -3 };
            ThreeSum(nums);
        }
        static IList<IList<int>> ThreeSum(int[] nums)
        {
            var res = new List<IList<int>>();
            int lastI = 1;
            Array.Sort(nums);
            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (nums[i] > 0) break;
                if (nums[i] == lastI) continue;
                lastI = nums[i];
                int li = i + 1, hi = nums.Length - 1, lastLi = int.MinValue;
                while (li <  hi)
                {
                    int sum = nums[i] + nums[li] + nums[hi];
                    if (sum > 0)
                        hi--;
                    else if (sum < 0)
                        li++;
                    else
                    {
                        if (nums[li] != lastLi)
                            res.Add(new List<int> {nums[i], nums[li], nums[hi]});
                        lastLi = nums[li];
                        hi--;
                        li++;
                    }
                }
            }
            return res;
        }
    }
}
