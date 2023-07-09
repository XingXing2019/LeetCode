using System;
using System.Collections.Generic;

namespace NumberOfBlackBlocks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public long[] CountBlackBlocks(int m, int n, int[][] coordinates)
        {
            var dict = new Dictionary<string, int>();
            foreach (var c in coordinates)
            {
                var blocks = GetBlocks(c[0], c[1], m, n);
                foreach (var block in blocks)
                {
                    if (!dict.ContainsKey(block))
                        dict[block] = 0;
                    dict[block]++;
                }
            }
            var record = new Dictionary<int, long>();
            foreach (var count in dict.Values)
            {
                if (!record.ContainsKey(count))
                    record[count] = 0;
                record[count]++;
            }
            var total = (long)(m - 1) * (n - 1);
            return new[] { total - dict.Count, record.GetValueOrDefault(1, 0), record.GetValueOrDefault(2, 0), record.GetValueOrDefault(3, 0), record.GetValueOrDefault(4, 0) };
        }

        public List<string> GetBlocks(int x, int y, int m, int n)
        {
            var res = new List<string>();
            if (x - 1 >= 0 && y - 1 >= 0)
                res.Add($"{x - 1}:{y - 1}:{x}:{y}");
            if (x - 1 >= 0 && y + 1 < n)
                res.Add($"{x - 1}:{y}:{x}:{y + 1}");
            if (y - 1 >= 0 && x + 1 < m)
                res.Add($"{x}:{y - 1}:{x + 1}:{y}");
            if (x + 1 < m && y + 1 < n)
                res.Add($"{x}:{y}:{x + 1}:{y + 1}");
            return res;
        }
    }
}
