using System;
using System.Xml.Schema;

namespace RangeSumQueryImmutable
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = {-2, 0, 3, -5, 2, -1};
            var numArray = new NumArray(nums);
            Console.WriteLine(numArray.SumRange(0, 2));
            Console.WriteLine(numArray.SumRange(2, 5));
            Console.WriteLine(numArray.SumRange(0, 5));
        }
    }
    public class NumArray
    {
        private int[] sums;
        public NumArray(int[] nums)
        {
            sums = new int[nums.Length + 1];
            if (nums.Length != 0)
            {
                sums[1] = nums[0];
                for (int i = 2; i < sums.Length; i++)
                    sums[i] = nums[i - 1] + sums[i - 1];
            }
            
        }

        public int SumRange(int i, int j)
        {
            return sums[j + 1] - sums[i];
        }
    }
}
