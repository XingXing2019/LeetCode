using System;

namespace NumberOfUnequalTripletsInArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int UnequalTriplets(int[] nums)
        {
            var res = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] == nums[j]) continue;
                    for (int k = j + 1; k < nums.Length; k++)
                    {
                        if (nums[k] == nums[j] || nums[k] == nums[i]) continue;
                        res++;
                    }
                }
            }
            return res;
        }
    }
}
