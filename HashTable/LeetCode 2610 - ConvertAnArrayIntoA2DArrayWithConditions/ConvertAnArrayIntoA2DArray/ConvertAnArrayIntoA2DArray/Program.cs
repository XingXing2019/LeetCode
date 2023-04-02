using System;
using System.Collections.Generic;
using System.Linq;

namespace ConvertAnArrayIntoA2DArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public IList<IList<int>> FindMatrix(int[] nums)
        {
            var freq = nums.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            nums = freq.Keys.ToArray();
            var row = freq.Max(x => x.Value);
            var res = new List<int>[row];
            for (int i = 0; i < res.Length; i++)
            {
                res[i] ??= new List<int>();
                foreach (var num in nums)
                {
                    if (freq[num] == 0) continue;
                    res[i].Add(num);
                    freq[num]--;
                }
            }
            return res;
        }
    }
}
