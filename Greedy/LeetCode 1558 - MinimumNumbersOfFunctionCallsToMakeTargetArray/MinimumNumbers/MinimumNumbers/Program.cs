using System;
using System.Collections.Generic;

namespace MinimumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int MinOperations(int[] nums)
        {
            int addOne = 0, maxBits = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                int bits = 0;
                while (nums[i] != 0)
                {
                    if ((nums[i] & 1) == 1)
                        addOne++;
                    bits++;
                    nums[i] >>= 1;
                }
                maxBits = Math.Max(maxBits, bits - 1);
            }
            return addOne + maxBits;
        }
    }
}
