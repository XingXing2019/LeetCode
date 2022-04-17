
using System;
using System.Collections.Generic;
using System.Linq;

namespace MinimumRoundToCompleteAllTasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] tasks =
            {
                66, 66, 63, 61, 63, 63, 64, 66, 66, 65, 66, 65, 61, 67, 68, 66, 62, 67, 61, 64, 66, 60, 69, 66, 65, 68,
                63, 60, 67, 62, 68, 60, 66, 64, 60, 60, 60, 62, 66, 64, 63, 65, 60, 69, 63, 68, 68, 69, 68, 61
            };
            Console.WriteLine(MinimumRounds(tasks));
        }

        public static int MinimumRounds(int[] tasks)
        {
            var dict = tasks.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            var freq = new Dictionary<int, int>();
            var res = 0;
            foreach (var count in dict.Values)
            {
                if (!freq.ContainsKey(count))
                    freq[count] = 0;
                freq[count]++;
            }
            foreach (var count in freq.Keys)
            {
                var min = int.MaxValue;
                for (int i = 0; count - i * 3 >= 0; i++)
                {
                    if ((count - i * 3) % 2 != 0) continue;
                    min = Math.Min(min, i + (count - i * 3) / 2);
                }
                if (min == int.MaxValue) return -1;
                res += min * freq[count];
            }
            return res;
        }
    }
}
