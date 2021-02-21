using System;

namespace FormArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] groups = new int[][]
            {
                new int[] {1, -1, -1},
                new int[] {3, -2, 0},
            };
            int[] nums = {1, -1, 0, 1, -1, -1, 3, -2, 0};
            Console.WriteLine(CanChoose(groups, nums));
        }
        public static bool CanChoose(int[][] groups, int[] nums)
        {
            int index = 0, start = 0;
            while (start < nums.Length && index < groups.Length)
            {
                if (Search(groups[index], nums, start))
                {
                    start += groups[index].Length;
                    index++;
                }
                else start++;
            }
            return index == groups.Length;
        }

        public static bool Search(int[] group, int[] nums, int start)
        {
            for (int i = 0; i < group.Length; i++)
                if (start + i >= nums.Length || group[i] != nums[start + i]) return false;
            return true;
        }
    }
}
