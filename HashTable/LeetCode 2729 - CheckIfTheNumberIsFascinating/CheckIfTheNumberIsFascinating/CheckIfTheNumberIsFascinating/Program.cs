using System;
using System.Collections.Generic;

namespace CheckIfTheNumberIsFascinating
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public bool IsFascinating(int n)
        {
            var digits = new HashSet<int>();
            var nums = new List<int> { n, n * 2, n * 3 };
            for (var i = 0; i < nums.Count; i++)
            {
                while (nums[i] != 0)
                {
                    if (!digits.Add(nums[i] % 10))
                        return false;
                    nums[i] /= 10;
                }
            }
            return digits.Count == 9 && !digits.Contains(0);
        }
    }
}
