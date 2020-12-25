using System;
using System.Collections.Generic;
using System.Linq;

namespace HighFive
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] items = new int[][]
            {
                new int[]{1, 91}, 
                new int[]{1, 92}, 
                new int[]{2, 93}, 
                new int[]{2, 97}, 
                new int[]{1, 60}, 
                new int[]{2, 77}, 
                new int[]{1, 65}, 
                new int[]{1, 87}, 
                new int[]{1, 100}, 
                new int[]{2, 100}, 
                new int[]{2, 76}
            };
            Console.WriteLine(HighFive_Linq(items));
        }
        static int[][] HighFive_Linq(int[][] items)
        {
            return items.GroupBy(x => x[0]).ToDictionary(x => x.Key, x => x.Select(y => y[1]).OrderByDescending(y => y).Take(5).Sum() / 5).Select(x => new[] { x.Key, x.Value }).OrderBy(x => x[0]).ToArray();
        }

        static int[][] HighFive_HashTable(int[][] items)
        {
            var scores = new Dictionary<int, List<int>>();
            foreach (var item in items)
            {
                if (!scores.ContainsKey(item[0]))
                    scores[item[0]] = new List<int> {item[1]};
                else
                    scores[item[0]].Add(item[1]);
            }
            var res = new int[scores.Count][];
            int index = 0;
            foreach (var kv in scores)
            {
                var score = kv.Value;
                score.Sort();
                score.Reverse();
                int sum = 0, count = 0;
                for (int i = 0; i < 5 && i < score.Count; i++)
                {
                    sum += score[i];
                    count++;
                }
                res[index++] = new int[]{kv.Key, sum / count};
            }
            return res;
        }
    }
}
