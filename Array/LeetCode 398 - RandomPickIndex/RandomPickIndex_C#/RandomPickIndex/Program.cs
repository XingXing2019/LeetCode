using System;
using System.Collections.Generic;

namespace RandomPickIndex
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    public class Solution
    {
        private readonly int[] _nums;
        private Random _random;
        public Solution(int[] nums)
        {
            _nums = nums;
            _random = new Random();
        }

        public int Pick(int target)
        {
            int count = 0;
            int res = -1;
            for (int i = 0; i < _nums.Length; i++)
            {
                if (_nums[i] == target && _random.Next(++count) == 0)
                    res = i;
            }
            return res;
        }
    }
}
