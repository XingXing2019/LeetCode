using System;
using System.Collections.Generic;

namespace SmallestRotationWithHighestScore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 3, 0, 2, 4 };
            Console.WriteLine(BestRotation(nums));
        }
        public static int BestRotation(int[] nums)
        {
            var moves = new List<int[]>[nums.Length];
            int max = 0, res = 0, maxRange = 0, freq = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                moves[i] = new List<int[]>();
                if (nums[i] > i)
                    moves[i].Add(new []{i + 1, i + nums.Length - nums[i]});
                else
                {
                    moves[i].Add(new []{0, i - nums[i]});
                    moves[i].Add(new[] { i + 1, nums.Length - 1 });
                }
                maxRange = Math.Max(maxRange, moves[i][^1][1]);
            }
            var record = new int[maxRange + 2];
            foreach (var move in moves)
            {
                foreach (var range in move)
                {
                    record[range[0]]++;
                    record[range[1] + 1]--;
                }
            }
            for (int i = 0; i < record.Length; i++)
            {
                freq += record[i];
                if (freq <= max) continue;
                max = freq;
                res = i;
            }
            return res;
        }
    }
}
