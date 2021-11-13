using System;
using System.Linq;

namespace MostBeautifulItemForEachQuery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] items = new[]
            {
                new[] { 1, 2 },
                new[] { 3, 2 },
                new[] { 2, 4 },
                new[] { 5, 6 },
                new[] { 3, 5 },
            };
            int[] queries = { 1, 2, 3, 4, 5, 6 };
            Console.WriteLine(MaximumBeauty(items, queries));
        }
        public static int[] MaximumBeauty(int[][] items, int[] queries)
        {
            items = items.OrderBy(x => x[0]).ToArray();
            var leftMax = new int[items.Length];
            var res = new int[queries.Length];
            var left = items[0][1];
            for (int i = 0; i < leftMax.Length; i++)
            {
                left = Math.Max(left, items[i][1]);
                leftMax[i] = left;
            }
            for (int i = 0; i < queries.Length; i++)
            {
                var index = BinarySearch(items, queries[i]);
                res[i] = index >= 0 && index < leftMax.Length ? leftMax[index] : 0;
            }
            return res;
        }

        public static int BinarySearch(int[][] items, int target)
        {
            int li = 0, hi = items.Length - 1;
            while (li <= hi)
            {
                int mid = li + (hi - li) / 2;
                if (items[mid][0] <= target)
                    li = mid + 1;
                else
                    hi = mid - 1;
            }
            return hi;
        }
    }
}
