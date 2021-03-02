using System;
using System.Collections.Generic;
using System.Linq;

namespace DivideArrayInSets
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = {1, 2, 3, 3, 4, 4, 5, 6};
            int k = 4;
            Console.WriteLine(IsPossibleDivide(nums, k));
        }
        public static bool IsPossibleDivide(int[] nums, int k)
        {
            var record = nums.GroupBy(x => x).OrderBy(x => x.Key).Select(x => new[]{x.Key, x.Count()}).ToArray();
            for (int i = 0; i < record.Length; i++)
            {
                if(record[i][1] == 0) continue;
                int first = record[i][0];
                int count = record[i][1];
                for (int j = 0; j < k; j++)
                {
                    if (i + j >= record.Length || first + j != record[i + j][0]) return false;
                    if (record[i + j][1] - count < 0) return false;
                    record[i + j][1] -= count;
                }
            }
            return true;
        }
    }
}
