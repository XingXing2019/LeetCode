using System;
using System.Linq;

namespace PartitionArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 5, 16, 3, 20, 9, 20, 16, 19, 6 };
            int k = 4;
            Console.WriteLine(PartitionArray(nums, k));
        }

        public static int PartitionArray(int[] nums, int k)
        {
            int max = nums.Max(), min = nums.Min();
            var record = new int[max + 1];
            foreach (var num in nums)
                record[num]++;
            int res = 0, index = min;
            while (index < record.Length)
            {
                var hasValue = false;
                for (int i = 0; i < k + 1 && index < record.Length; i++)
                {
                    if (record[index++] != 0)
                        hasValue = true;
                }
                if (hasValue)
                    res++;
                while (index < record.Length && record[index] == 0)
                    index++;
            }
            return res;
        }
    }
}
