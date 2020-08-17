using System;

namespace _3SumSmaller
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int ThreeSumSmaller(int[] nums, int target)
        {
            Array.Sort(nums);
            int res = 0;
            for (int i = 0; i < nums.Length - 2; i++)
            {
                int sum = target - nums[i];
                int li = i + 1, hi = nums.Length - 1;
                while (li < hi)
                {
                    if (nums[li] + nums[hi] < sum)
                    {
                        res += hi - li;
                        li++;
                    }
                    else
                        hi--;
                }
            }
            return res;
        }
    }
}
