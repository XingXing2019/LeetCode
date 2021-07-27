//思路为贪心算法加双指针。
//设置res，初始值设为0。设置closest代表三数之和与target差值的绝对值，初始值设为int的最大值。对数组排序。
//在第一个和倒数第三个元素之间遍历数组。设置current代表当前遍历到的数字，left指向current右边第一个数字，right指向数组最后一个数字。
//在left小于right的条件下遍历current右边的数组。设置total代表left和right所指向数字与current之和。
//如果total与target差值的绝对值小于closest，则替换closest为total与target差值的绝对值。并且将res设为total。
//如果total小于target，则使left向右移动，以求找到更大的total与target靠近。否则使right向左移动，以求找到更小的total与target靠近。
using System;

namespace _3SumClosest
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 9, -4, 3, 500 };
            int target = 5;
            Console.WriteLine(ThreeSumClosest(nums, target));
        }
        static int ThreeSumClosest(int[] nums, int target)
        {
            Array.Sort(nums);
            var gap = int.MaxValue;
            var res = 0;
            int last = nums[0] - 1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == last) continue;
                last = nums[i];
                int li = i + 1, hi = nums.Length - 1;
                while (li < hi)
                {
                    int sum = nums[i] + nums[li] + nums[hi];
                    if (sum == target) return target;
                    if (Math.Abs(sum - target) < gap)
                    {
                        gap = Math.Abs(sum - target);
                        res = sum;
                    }
                    if (sum > target) hi--;
                    else li++;
                }
            }
            return res;
        }
    }
}
