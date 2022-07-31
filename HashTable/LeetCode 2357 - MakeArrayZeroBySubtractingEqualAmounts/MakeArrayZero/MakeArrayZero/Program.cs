using System;
using System.Collections.Generic;

namespace MakeArrayZero
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int MinimumOperations(int[] nums)
        {
            var set = new HashSet<int>(nums);
            set.Remove(0);
            return set.Count;
        }
    }
}
