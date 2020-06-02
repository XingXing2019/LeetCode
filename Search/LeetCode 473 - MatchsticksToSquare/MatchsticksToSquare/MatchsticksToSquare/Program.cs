//如果火柴杆数量小4，则返回false。统计火柴杆总长度。如果总长不能被4整除则返回false。对nums从大到小排序可以优化搜索效率。
//创建一个长度为4的数组bucket，用于代表四个边的长度。用深搜加回溯的方法将火柴杆放入数组的四个位置，试图达到每条边长度为总长的四分之一。
//创建Generate方法，传入参数为i(火柴杆的index)，nums，target(总长的四分之一)和bucket。
//如果i到达nums结尾时证明所有火柴杆已经放完，返回是否每条边都为target。
//否则试着向bucket的四个位置放置火柴杆。如果当前尝试位置已有的火柴杆加上将要放入的火柴杆大于target，则跳过该次尝试。否则将当前火柴杆放入。
//然后将递归调用Generate，将i+1传入。如果其结果为true，则返回true。否则证明不应该将当前火柴杆放入该位置，则将其取出。
//循环结束后如仍未返回true，则证明当前给定火柴杆不能组成正方形，则返回false。
//在主方法中调用Generate方法，将0作为i传入。
using System;

namespace MatchsticksToSquare
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static bool Makesquare(int[] nums)
        {
            if (nums.Length < 4)
                return false;
            int sum = 0;
            foreach (var n in nums)
                sum += n;
            if (sum % 4 != 0)
                return false;
            Array.Sort(nums);
            Array.Reverse(nums);
            int[] bucket = new int[4];
            return Generate(0, nums, sum / 4, bucket);
        }
        static bool Generate(int i, int[] nums, int target, int[] bucket)
        {
            if (i == nums.Length)
                return bucket[0] == target && bucket[1] == target && bucket[2] == target && bucket[3] == target;
            for (int j = 0; j < 4; j++)
            {
                if (bucket[j] + nums[i] > target)
                    continue;
                bucket[j] += nums[i];
                if (Generate(i + 1, nums, target, bucket))
                    return true;
                bucket[j] -= nums[i];
            }
            return false;
        }
    }
}
