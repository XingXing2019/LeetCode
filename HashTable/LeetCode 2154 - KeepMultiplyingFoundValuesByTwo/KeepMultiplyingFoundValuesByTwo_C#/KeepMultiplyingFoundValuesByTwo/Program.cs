using System;
using System.Collections.Generic;

namespace KeepMultiplyingFoundValuesByTwo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int FindFinalValue(int[] nums, int original)
        {
            var set = new HashSet<int>(nums);
            while (set.Contains(original))
                original *= 2;
            return original;
        }
    }
}
