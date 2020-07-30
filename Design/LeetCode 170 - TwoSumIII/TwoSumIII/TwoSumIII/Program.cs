using System;
using System.Collections.Generic;
using System.Linq;

namespace TwoSumIII
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    public class TwoSum
    {
        private List<int> nums;
        public TwoSum()
        {
            nums = new List<int>();
        }
        public void Add(int number)
        {
            nums.Add(number);
        }

        public bool Find(int value)
        {
            var set = new HashSet<int>();
            foreach (var num in nums)
            {
                if (set.Contains(value - num))
                    return true;
                set.Add(num);
            }
            return false;
        }
    }
}
