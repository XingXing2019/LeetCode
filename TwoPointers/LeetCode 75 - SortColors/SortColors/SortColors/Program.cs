//第一种方法为原地修改数组。创建zero指针代表从数组左边开始应该是0的位置，创建two指针代表从数组右边开始应该是2的位置。创建index指针用于遍历数组。
//在index <= two的条件下遍历数组，因为index与two相遇后，two右边的数字肯定已经全部为2。这样可以保证不会将调整好的数组再次修改错误。
//当index指向数字为1时，则index向右移动一位。当index指向数字为0时，则使其与zero指向数字交换，并使zero和index都向右移动一位。
//当index指向数字为2时，则使其与two指向数字交换，同时two向左移动一位。(这时index不能动，因为前一次two指向的数字有可能也是2，则要与two新指向的数字在做一次交换)
//第二种方法为先遍历一遍数组，分别记录0，1，2的个数，再遍历一遍数组，将相应元素修改为0，1，2。此种方法逻辑简单。
using System;

namespace SortColors
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 2, 0, 2, 1, 1, 0 };
            SortColors_TwoPointers(nums);
        }
        static void SortColors_TwoPointers(int[] nums)
        {
            int zero = 0, two = nums.Length - 1, index = 0;
            while (index <= two)
            {
                if (nums[index] == 1)
                    index++;
                else if (nums[index] == 0)
                {
                    int temp = nums[index];
                    nums[index] = nums[zero];
                    nums[zero] = temp;
                    zero++;
                    index++;
                }
                else
                {
                    int temp = nums[index];
                    nums[index] = nums[two];
                    nums[two] = temp;
                    two--;
                }
            }
        }
        static void SortColors_TwoLoops(int[] nums)
        {
            int count0 = 0;
            int count1 = 0;
            int count2 = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                    count0++;
                else if (nums[i] == 1)
                    count1++;
                else
                    count2++;
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if (count0 > 0)
                {
                    nums[i] = 0;
                    count0--;
                }
                else if (count1 > 0)
                {
                    nums[i] = 1;
                    count1--;
                }
                else
                    nums[i] = 2;
            }
        }
    }
}
