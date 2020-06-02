//思路为使用left和right两个指针从数组两边向中间扫描。
//创建left和right指针分别指向数组的头尾。创建res用于记录结果，初始值设为-1。
//在left <= right的条件下遍历数组，一旦发现left或者right所指向元素等于target，就将res设为相应的left或者right，并停止遍历。
//如果target与left指向元素差的绝对值大于target于right指向元素差的绝对值(找出谁离target更近)，则让right向左移动。否则让left向右移动。
using System;

namespace SearchInRotatedSortedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = {4, 5, 6, 7, 0, 1, 2};
            int target = 4;
            Console.WriteLine(Search1(nums, target));
        }

        static int Search1(int[] nums, int target)
        {
            int li = 0, hi = nums.Length - 1;
            while (li <= hi)
            {
                int mid = li + (hi - li) / 2;
                if (nums[mid] == target)
                    return mid;
                if (nums[mid] < nums[hi])
                {
                    if (nums[mid] < target && target <= nums[hi])
                        li = mid + 1;
                    else
                        hi = mid - 1;
                }
                else
                {
                    if (nums[li] <= target && target < nums[mid])
                        hi = mid - 1;
                    else
                        li = mid + 1;
                }
            }
            return -1;
        }
        static int Search2(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;
            int res = -1;
            while (left <= right)
            {
                if (nums[left] == target)
                {
                    res = left;
                    break;
                }
                else if (nums[right] == target)
                {
                    res = right;
                    break;
                }
                if (Math.Abs(target - nums[left]) > Math.Abs(target - nums[right]))
                    right--;
                else
                    left++;
            }
            return res;
        }
    }
}
