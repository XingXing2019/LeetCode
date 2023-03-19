using System;

namespace MaximizeGreatnessOfAnArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int MaximizeGreatness(int[] nums)
        {
            Array.Sort(nums);
            int p1 = 0, p2 = 0;
            while (p2 < nums.Length)
            {
                if (nums[p2] > nums[p1])
                    p1++;
                p2++;
            }
            return p1;
        }
    }
}
