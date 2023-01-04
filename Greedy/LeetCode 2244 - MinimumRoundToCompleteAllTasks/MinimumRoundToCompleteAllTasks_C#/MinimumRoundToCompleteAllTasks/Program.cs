
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
            var freq = tasks.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            var res = 0;
            foreach (var count in freq.Values)
            {
                if (count == 1)
                    return -1;
                if (count % 3 == 0)
                    res += count / 3;
                else
                    res += count % 3 == 1 ? (count - 4) / 3 + 2 : count / 3 + 1;
            }
            return res;
        }
    }
}
