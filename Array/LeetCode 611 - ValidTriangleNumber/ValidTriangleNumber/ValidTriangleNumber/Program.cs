//先将数组排序，保证较大的数字在后面。则如果前面两个较小数字之和大于后面的较大数字，则可以组成三角形。创建count记录结果。
//用p3指针从最后一个数字倒着遍历数组。对于每个遍历到的数字，需要从前面的数字中找到一个窗口，窗口中任意两个数字之和都大于这个数字。
//创建p1指针指向第一个数字(最小)，p2指针指向p3前一个数字。在p1小于p2的条件下遍历。
//如果p1和p2指向数字之和小于或等于p3指向数字，则需要使p1右移以求找到更大的数字。
//如果p1和p2指向数字之和大于p3指向数字，则证明此时p1和p2之间所有数字都符合条件，则将p2与p1只差加入count。同时使p2左移更换窗口右边界。
using System;

namespace ValidTriangleNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 2, 2, 3, 4, 4, 5, 5, 6 };
            Console.WriteLine(TriangleNumber(nums));
        }
        static int TriangleNumber(int[] nums)
        {
            int len = nums.Length;
            if (len < 3)
                return 0;
            int count = 0;
            Array.Sort(nums);
            for (int p3 = nums.Length - 1; p3 >= 2; p3--)
            {
                int p1 = 0;
                int p2 = p3 - 1;
                while (p1 < p2)
                {
                    if (nums[p1] + nums[p2] <= nums[p3])
                        p1++;
                    else
                    {
                        count += p2 - p1;
                        p2--;
                    }
                }
            }
            return count;
        }
    }
}
