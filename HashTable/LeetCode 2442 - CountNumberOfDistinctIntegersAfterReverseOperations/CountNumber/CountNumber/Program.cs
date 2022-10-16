using System;
using System.Collections.Generic;

namespace CountNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int CountDistinctIntegers(int[] nums)
        {
            var unique = new HashSet<int>(nums);
            var res = new HashSet<int>();
            foreach (var num in unique)
            {
                res.Add(num);
                res.Add(Reverse(num));
            }
            return res.Count;
        }

        private int Reverse(int num)
        {
            var res = 0;
            while (num != 0)
            {
                res = res * 10 + num % 10;
                num /= 10;
            }
            return res;
        }
    }
}
