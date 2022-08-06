using System;
using System.Collections.Generic;
using System.Linq;

namespace MergeSimilarItems
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public IList<IList<int>> MergeSimilarItems(int[][] items1, int[][] items2)
        {
            var dict = new Dictionary<int, int>();
            foreach (var item in items1)
                dict[item[0]] = dict.GetValueOrDefault(item[0], 0) + item[1];
            foreach (var item in items2)
                dict[item[0]] = dict.GetValueOrDefault(item[0], 0) + item[1];
            return dict.OrderBy(x => x.Key).Select(x => new int[] { x.Key, x.Value }).ToArray();
        }
    }
}
