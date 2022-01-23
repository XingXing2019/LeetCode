using System;
using System.Collections.Generic;
using System.Linq;

namespace FindAllLonelyNumbersInTheArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public IList<int> FindLonely(int[] nums)
        {
            var dict = nums.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            return dict.Where(x => x.Value == 1 && !dict.ContainsKey(x.Key + 1) && !dict.ContainsKey(x.Key - 1)).Select(x => x.Key).ToList();
        }
    }
}
