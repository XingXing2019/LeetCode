using System;
using System.Collections.Generic;
using System.Linq;

namespace CountArtifactsThatCanBeExtracted
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int DigArtifacts(int n, int[][] artifacts, int[][] dig)
        {
            var record = new HashSet<string>[artifacts.Length];
            var map = new Dictionary<string, int>();
            for (int i = 0; i < artifacts.Length; i++)
            {
                record[i] = new HashSet<string>();
                for (int r = artifacts[i][0]; r <= artifacts[i][2]; r++)
                {
                    for (int c = artifacts[i][1]; c <= artifacts[i][3]; c++)
                    {
                        var pos = $"{r}:{c}";
                        map[pos] = i;
                        record[i].Add(pos);
                    }
                }
            }
            for (var i = 0; i < dig.Length; i++)
            {
                var pos = $"{dig[i][0]}:{dig[i][1]}";
                if (!map.ContainsKey(pos)) continue;
                var index = map[pos];
                record[index].Remove(pos);
            }
            return record.Count(t => t.Count == 0);
        }
    }
}
