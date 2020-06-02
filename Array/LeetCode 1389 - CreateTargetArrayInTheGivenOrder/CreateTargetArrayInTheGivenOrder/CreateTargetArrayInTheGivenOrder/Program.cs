using System;
using System.Collections.Generic;

namespace CreateTargetArrayInTheGivenOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 4, 2, 4, 3, 2 };
            int[] index = { 0, 0, 1, 3, 1 };
            Console.WriteLine(CreateTargetArray(nums, index));
        }
        static int[] CreateTargetArray(int[] nums, int[] index)
        {
            var record = new HashSet<int>();
            for (int i = 0; i < index.Length; i++)
            {
                if (!record.Contains(index[i]))
                    record.Add(index[i]);
                else
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (index[j] >= index[i])
                            index[j]++;
                        if (!record.Contains(index[j]))
                            record.Add(index[j]);
                    }
                }
            }
            var res = new int[nums.Length];
            for (int i = 0; i < index.Length; i++)
                res[index[i]] = nums[i];
            return res;
        }
    }
}
