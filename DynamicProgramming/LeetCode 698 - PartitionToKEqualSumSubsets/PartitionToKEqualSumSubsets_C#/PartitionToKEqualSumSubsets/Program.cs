//与LeetCode 473思路相同，利用深搜加回溯可以解决。但是如果利用动态规划可能可以进一步优化算法。
using System;

namespace PartitionToKEqualSumSubsets
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 4, 3, 2, 3, 5, 2, 1 };
            int k = 2;
            Console.WriteLine(CanPartitionKSubsets(nums, k));
        }
        static bool CanPartitionKSubsets(int[] nums, int k)
        {
            int sum = 0;
            foreach (var n in nums)
                sum += n;
            if (sum % k != 0)
                return false;
            int target = sum / k;
            Array.Sort(nums);
            Array.Reverse(nums);
            int[] bucket = new int[k];
            return DistributeNums(0, nums, target, bucket);
        }
        static bool DistributeNums(int i, int[]nums, int target, int[] bucket)
        {
            if(i == nums.Length)
            {
                foreach (var b in bucket)
                    if (b != target)
                        return false;
                return true;
            }
            for (int j = 0; j < bucket.Length; j++)
            {
                if (bucket[j] + nums[i] > target)
                    continue;
                bucket[j] += nums[i];
                if (DistributeNums(i + 1, nums, target, bucket))
                    return true;
                bucket[j] -= nums[i];
            }
            return false;
        }
    }
}
