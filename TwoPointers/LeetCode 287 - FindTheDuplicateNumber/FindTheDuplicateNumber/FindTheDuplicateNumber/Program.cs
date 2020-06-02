//遍历数组，将遍历到的数字存入列表，如果当前遍历到的数字已经在列表中，则该数字为重复数字。
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;

namespace FindTheDuplicateNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 3, 4, 2, 2 };
            Console.WriteLine(FindDuplicate2(nums));
        }
        
        //Two points O(n)
        static int FindDuplicate1(int[] nums)
        {
            int slow = nums[0];
            int fast = nums[nums[0]];
            while (fast != slow)
            {
                slow = nums[slow];
                fast = nums[nums[fast]];
            }
            fast = 0;
            while (fast != slow)
            {
                fast = nums[fast];
                slow = nums[slow];
            }
            return fast;
        }

        //Binary search O(n * log(n))
        static int FindDuplicate2(int[] nums)
        {
            int li = 1, hi = nums.Length - 1;
            while (li < hi)
            {
                int mid = li + (hi - li) / 2;
                int count = 0;
                foreach (var num in nums)
                    if (num <= mid)
                        count++;
                if (count > mid)
                    hi = mid;
                else
                    li = mid + 1;
            }
            return li;
        }

        //Hash Table
        static int FindDuplicate3(int[] nums)
        {
            var record = new HashSet<int>();
            foreach (var num in nums)
            {
                if (record.Contains(num))
                    return num;
                else
                    record.Add(num);
            }
            return -1;
        }
    }
}
