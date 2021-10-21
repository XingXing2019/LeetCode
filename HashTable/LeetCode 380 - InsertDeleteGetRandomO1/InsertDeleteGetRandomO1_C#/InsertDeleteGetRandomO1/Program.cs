using System;
using System.Collections.Generic;

namespace InsertDeleteGetRandomO1
{
    class Program
    {
        static void Main(string[] args)
        {
            var set = new RandomizedSet();
            set.Insert(0);
            set.Insert(1);
            set.Remove(0);
            set.Insert(2);
            set.Remove(1);
            Console.WriteLine(set.GetRandom());
        }
    }
    public class RandomizedSet
    {
        private Dictionary<int, int> dict;
        private List<int> nums;
        private Random random;
        public RandomizedSet()
        {
            dict = new Dictionary<int, int>();
            nums = new List<int>();
            random = new Random();
        }

        public bool Insert(int val)
        {
            if (dict.ContainsKey(val))
                return false;
            dict.Add(val, nums.Count);
            nums.Add(val);
            return true;
        }

        public bool Remove(int val)
        {
            if (!dict.ContainsKey(val))
                return false;
            var index = dict[val];
            var last = nums[^1];
            dict[last] = index;
            nums[^1] = val;
            nums[index] = last;
            nums.RemoveAt(nums.Count - 1);
            dict.Remove(val);
            return true;
        }

        public int GetRandom()
        {
            var index = random.Next(0, nums.Count);
            return nums[index];
        }
    }

}
