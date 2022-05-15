using System;
using System.ComponentModel.DataAnnotations;

namespace LargestCombination
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int LargestCombination(int[] candidates)
        {
            var res = 0;
            for (int i = 0; i < 32; i++)
            {
                var count = 0;
                foreach (var num in candidates)
                {
                    if (((num >> i) & 1) == 1)
                        count++;
                }
                res = Math.Max(res, count);
            }
            return res;
        }
    }
}
