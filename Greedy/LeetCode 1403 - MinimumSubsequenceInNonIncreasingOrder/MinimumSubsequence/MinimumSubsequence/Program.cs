using System;
using System.Collections.Generic;
using System.Linq;

namespace MinimumSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = {4, 3, 10, 9, 8};
            Console.WriteLine(MinSubsequence(nums));
        }
        static IList<int> MinSubsequence(int[] nums)
        {
            var res = new List<int>();
            var record = new int[nums.Max(num => num) + 1];
            foreach (var num in nums)
                record[num]++;
            int sum = nums.Sum(num => num);
            int subSum = 0;
            var enough = false;
            for (int i = record.Length - 1; i >= 0; i--)
            {
                if (enough)
                    break;
                if (record[i] == 0) continue;
                for (int j = 0; j < record[i]; j++)
                {
                    if (subSum > sum)
                    {
                        enough = true;
                        break;
                    }
                    res.Add(i);
                    subSum += i;
                    sum -= i;
                }
            }
            return res;
        }
    }
}
