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
    public class TwoSum_Dictionary
    {

        private Dictionary<int, int> nums;
        private HashSet<int> values;
        public TwoSum_Dictionary()
        {
            nums = new Dictionary<int, int>();
            values = new HashSet<int>();
        }

        public void Add(int number)
        {
            if (!nums.ContainsKey(number))
                nums[number] = 0;
            nums[number]++;
        }

        public bool Find(int value)
        {
            if (values.Contains(value))
                return true;
            foreach (var kv in nums)
            {
                if (kv.Key != value - kv.Key && nums.ContainsKey(value - kv.Key) ||
                    kv.Key == value - kv.Key && kv.Value > 1)
                {
                    values.Add(value);
                    return true;
                }
            }
            return false;
        }
    }
}
