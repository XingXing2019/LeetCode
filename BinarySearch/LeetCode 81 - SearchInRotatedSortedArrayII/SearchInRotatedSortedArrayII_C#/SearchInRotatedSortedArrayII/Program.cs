using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace SearchInRotatedSortedArrayII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 1, 1, 1, 2, 1, 1 };
            int target = 2;
            Console.WriteLine(Search_BinarySearch(nums, target));
        }
        static bool Search(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;
            bool res = false;
            while (left <= right)
            {
                if (nums[left] == target)
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

        public static bool Search_BinarySearch(int[] nums, int target)
        {
            int li = 0, hi = nums.Length - 1;
            while (li <= hi)
            {
                var mid = li + (hi - li) / 2;
                if (nums[mid] == target) return true;
                if (nums[mid] < nums[hi])
                {
                    if (nums[mid] < target && target <= nums[hi])
                        li = mid + 1;
                    else
                        hi = mid - 1;
                }
                else if (nums[mid] > nums[hi])
                {
                    if (nums[li] <= target && target < nums[mid])
                        hi = mid - 1;
                    else
                        li = mid + 1;
                }
                else
                {
                    return nums[mid..hi].Contains(target) || nums[li..mid].Contains(target);
                }
            }
            return nums[li] == target;
        }
    }
}
