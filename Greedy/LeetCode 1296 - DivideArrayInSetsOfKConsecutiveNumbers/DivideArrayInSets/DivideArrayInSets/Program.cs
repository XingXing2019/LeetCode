using System;
using System.Linq;

namespace DivideArrayInSets
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public bool IsPossibleDivide(int[] nums, int k)
        {
            if (nums.Length % k != 0)
                return false;
            int max = nums.Max(num => num);
            int[] record = new int[max + 1];
            foreach (var num in nums)
                record[num]++;
            for (int i = 0; i < record.Length; i++)
            {
                if (record[i] == 0)
                    continue;
                int count = record[i];
                for (int j = 0; j < k; j++)
                {
                    record[i + j] -= count;
                    if (record[i + j] < 0)
                        return false;
                }
            }
            return true;
        }
    }
}
