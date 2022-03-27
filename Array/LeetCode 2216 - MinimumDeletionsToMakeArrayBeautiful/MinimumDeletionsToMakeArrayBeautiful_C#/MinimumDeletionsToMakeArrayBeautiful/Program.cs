using System;

namespace MinimumDeletionsToMakeArrayBeautiful
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        
        public int MinDeletion(int[] nums)
        {
            var res = 0;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if ((i - res) % 2 == 0 && nums[i] == nums[i + 1])
                    res++;
            }
            return (nums.Length - res) % 2 == 0 ? res : res + 1;
        }
    }
}
