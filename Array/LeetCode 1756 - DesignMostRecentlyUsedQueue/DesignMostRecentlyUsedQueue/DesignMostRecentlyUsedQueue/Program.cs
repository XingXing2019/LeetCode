using System;

namespace DesignMostRecentlyUsedQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class MRUQueue
    {
        private int[] nums;
        public MRUQueue(int n)
        {
            nums = new int[n];
            for (int i = 1; i <= n; i++)
                nums[i - 1] = i;
        }

        public int Fetch(int k)
        {
            for (int i = k - 1; i < nums.Length - 1; i++)
            {
                int temp = nums[i];
                nums[i] = nums[i + 1];
                nums[i + 1] = temp;
            }
            return nums[^1];
        }
    }
}
