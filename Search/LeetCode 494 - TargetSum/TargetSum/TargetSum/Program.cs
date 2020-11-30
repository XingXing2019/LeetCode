using System;

namespace TargetSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = {1, 1, 1, 1, 1};
            int S = 3;
            Console.WriteLine(FindTargetSumWays(nums, S));
        }
        static int FindTargetSumWays(int[] nums, int S)
        {
            var res = 0;
            DFS(nums, S, 0, ref res);
            return res;
        }

        static void DFS(int[] nums, int S, int index, ref int res)
        {
            if (index == nums.Length)
            {
                if (S == 0)
                    res++;
            }
            else
            {
                DFS(nums, S + nums[index], index + 1, ref res);
                DFS(nums, S - nums[index], index + 1, ref res);
            }
        }
    }
}
