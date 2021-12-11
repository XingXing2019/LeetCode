using System;
using System.Collections.Generic;
using System.Linq;

namespace FindSubsequenceOfLengthK
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nusm = { 27, -37, -18, -25, 14, -36, 23, 28, -15, 35, -9, 1 };
            int k = 5;
            Console.WriteLine(MaxSubsequence(nusm, k));
        }

        public static int[] MaxSubsequence(int[] nums, int k)
        {
            var sorted = nums.Select((value, index) => new int[] { index, value }).OrderByDescending(x => x[1]).ToArray();
            var res = new int[k];
            var record = new int[nums.Length];
            Array.Fill(record, int.MinValue);
            for (int i = 0; i < k; i++)
                record[sorted[i][0]] = sorted[i][1];
            var index = 0;
            foreach (var num in record)
            {
                if (num == int.MinValue) continue;
                res[index++] = num;
            }
            return res;
        }
    }
}
