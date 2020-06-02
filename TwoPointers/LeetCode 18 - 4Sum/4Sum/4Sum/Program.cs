//思路和LeetCode15-3Sum一样。先对数组排序，创建res接收符合条件的数组。创建currentI代表代表i指向的元素，初始值设为int.MaxValue。
//用i指针从第一个元素开始遍历，到nums.Length - 4(包含)结束，如果当前i所指向元素和上一轮i所指向的元素(currentI)相同，则跳过此轮遍历。将currentI设为当前i所指向的元素。
//创建currentJ代表代表j指向的元素，初始值设为int.MaxValue。用j指针从i后面一个元素开始遍历，到nums.Length - 3(包含)结束。
//如果当前j所指向元素和上一轮j所指向的元素(currentJ)相同，则跳过此轮遍历。将currentJ设为当前j所指向的元素。
//创建left和right指针指向j右边第一个元素和数组尾的元素。
//在left小于right的条件下遍历，创建currentL和currentR代表当前left和right所指向的元素。创建total代表四个数字的加和。
//如果total等于target，则创建tem数组，并将四个数字添加入tem，并将tem条加入res。并且在left小于right和left以及right所指向元素不等于上一轮currentL和currentR的条件下，分别让left加1，right减1
//如果total小于target，则让left加1，以求找到更大的值。
//如果total大于target，则让right减1，以求找到更小的值。
using System;
using System.Collections.Generic;

namespace _4Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 0, -1, 0, -2, 2 };
            int target = 0;
            Console.WriteLine(FourSum(nums, target));
        }
        static IList<IList<int>> FourSum(int[] nums, int target)
        {
            Array.Sort(nums);
            var res = new List<IList<int>>();
            int currentI = int.MaxValue;
            for (int i = 0; i <= nums.Length - 4; i++)
            {
                if (nums[i] == currentI)
                    continue;
                currentI = nums[i];
                int currentJ = int.MaxValue;
                for (int j = i + 1; j <= nums.Length - 3; j++)
                {
                    if (nums[j] == currentJ)
                        continue;
                    currentJ = nums[j];
                    int left = j + 1;
                    int right = nums.Length - 1;
                    while (left < right)
                    {
                        int currentL = nums[left];
                        int currentR = nums[right];
                        int total = currentI + currentJ + currentL + currentR;
                        if (total == target)
                        {
                            List<int> tem = new List<int>();
                            tem.Add(currentI);
                            tem.Add(currentJ);
                            tem.Add(currentL);
                            tem.Add(currentR);
                            while (nums[left] == currentL && left < right)
                                left++;
                            while (nums[right] == currentR && left < right)
                                right--;
                            res.Add(tem);
                        }
                        else if (total < target)
                            left++;
                        else if (total > target)
                            right--;
                    }
                }
            }
            return res;
        }
    }
}
