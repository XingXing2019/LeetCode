using System;

namespace PredictTheWinner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 2, 14 };
            Console.WriteLine(PredictTheWinner(nums));
        }

        public static bool PredictTheWinner(int[] nums)
        {
            return DFS(nums, 0, nums.Length - 1, 0, 0, 0);
        }

        public static bool DFS(int[] nums, int li, int hi, int turn, int A, int B)
        {
            if (li > hi) return A >= B;
            return turn % 2 == 0
                ? DFS(nums, li + 1, hi, turn + 1, A + nums[li], B) || DFS(nums, li, hi - 1, turn + 1, A + nums[hi], B)
                : DFS(nums, li + 1, hi, turn + 1, A, B + nums[li]) && DFS(nums, li, hi - 1, turn + 1, A, B + nums[hi]);
        }
    }
}
