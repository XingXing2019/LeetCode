using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

namespace FindTheDuplicateNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 3, 4, 2, 2 };
            Console.WriteLine(FindDuplicate_BinarySearch(nums));
        }
        
        //Two points O(n)
        static int FindDuplicate_FloydTortoiseHare(int[] nums)
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

        static int FindDuplicate_Sort(int[] nums)
        {
            Array.Sort(nums);
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == nums[i - 1])
                    return nums[i];
            }
            return -1;
        }

        static int FindDuplicate_BinarySearch(int[] nums)
        {
            int li = 1, hi = nums.Length;
            while (li < hi)
            {
                int mid = li + (hi - li) / 2;
                int count = nums.Count(x => x <= mid);
                if (count > mid)
                    hi = mid;
                else
                    li = mid + 1;
            }
            return li;
        }

        static int FindDuplicate_HashTable(int[] nums)
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
