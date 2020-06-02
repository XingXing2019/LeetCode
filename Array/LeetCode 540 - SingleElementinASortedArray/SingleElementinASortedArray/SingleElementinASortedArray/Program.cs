//二分搜索，如果发现mid是偶数，而且nums[mid]与nums[mid + 1]相等，证明单独数字在后面一半数组中，如果nums[mid]与nums[mid + 1]不相等，则单独数字在前一半数组中。
//如果发现mid时奇数，情况正好相反。
using System;

namespace SingleElementinASortedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 3, 3, 7, 7, 10, 10, 11 };
            Console.WriteLine(SingleNonDuplicate(nums));
        }
        static int SingleNonDuplicate(int[] nums)
        {
            int li = 0, hi = nums.Length - 1;
            while (li < hi)
            {
                int mid = li + (hi - li) / 2;
                if (mid % 2 == 0)
                {
                    if (nums[mid] == nums[mid + 1])
                        li = mid + 1;
                    else
                        hi = mid;
                }
                else
                {
                    if (nums[mid] != nums[mid + 1])
                        li = mid + 1;
                    else
                        hi = mid;
                }
            }
            return nums[li];
        }
    }
}
