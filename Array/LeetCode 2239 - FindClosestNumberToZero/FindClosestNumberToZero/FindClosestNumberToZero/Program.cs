using System;
using System.Collections.Generic;
using System.Linq;

namespace FindClosestNumberToZero
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int FindClosestNumber(int[] nums)
        {
            var dict = new Dictionary<int, List<int>>();
            var min = int.MaxValue;
            foreach (var num in nums)
            {
                var abs = Math.Abs(num);
                if (!dict.ContainsKey(abs))
                    dict[abs] = new List<int>();
                dict[abs].Add(num);
                min = Math.Min(min, abs);
            }
            return dict[min].Max();
        }
    }
}
