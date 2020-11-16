//方法一：创建int型HashSet。遍历数组，如果当前数字在HashSet中，则返回true。
//否则，先将当前数字存入HashSet，然后在i-k不越界的情况下，将nums[i - k]从HashSet中祛除。遍历结束后返回false。
//方法二：创建record字典。遍历数组，如果当前数字不在record中，则将其与其index加入record。
//否则在当前index与当前数字在record中存储的index只差不大于k的条件下返回true。否则将record中当前数字对应的index更新为当前index。
//遍历结束后返回false。
using System;
using System.Collections.Generic;

namespace ContainsDuplicateII
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 2, 3, 1, 2, 3 };
            int k = 2;
            Console.WriteLine(ContainsNearbyDuplicate1(nums, k));
        }
        static bool ContainsNearbyDuplicate1(int[] nums, int k)
        {
            var record = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (record.Contains(nums[i]))
                    return true;
                record.Add(nums[i]);
                if (i >= k)
                    record.Remove(nums[i - k]);
            }
            return false;
        }
        static bool ContainsNearbyDuplicate2(int[] nums, int k)
        {
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey(nums[i]) && i - dict[nums[i]] <= k)
                    return true;
                dict[nums[i]] = i;
            }
            return false;
        }
    }
}
