using System;
using System.Collections.Generic;

namespace CreateSortedArraythroughInstructions
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] instructions = {1, 3, 3, 3, 2, 4, 2, 1, 2};
            Console.WriteLine(CreateSortedArray(instructions));
        }
        static int CreateSortedArray(int[] instructions)
        {
            long res = 0;
            var nums = new List<int>();
            foreach (var instruction in instructions)
            {
                int li = 0, hi = nums.Count - 1;
                while (li <= hi)
                {
                    int mid = li + (hi - li) / 2;
                    if (nums[mid] >= instruction) hi = mid - 1;
                    else li = mid + 1;
                }
                int less = li;
                li = 0; hi = nums.Count - 1;
                while (li <= hi)
                {
                    int mid = li + (hi - li) / 2;
                    if (nums[mid] <= instruction) li = mid + 1;
                    else hi = mid - 1;
                }
                int greater = nums.Count - li;
                res += Math.Min(less, greater);
                nums.Insert(li, instruction);
            }
            return (int) (res % (1_000_000_000 + 7));
        }
    }
}
