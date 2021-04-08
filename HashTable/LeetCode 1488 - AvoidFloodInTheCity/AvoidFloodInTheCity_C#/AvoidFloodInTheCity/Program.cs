using System;
using System.Collections.Generic;

namespace AvoidFloodInTheCity
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rains = { 69, 0, 0, 0, 69 };
            Console.WriteLine(AvoidFlood(rains));
        }
        static int[] AvoidFlood(int[] rains)
        {
            var noRainDays = new List<int>();
            var res = new int[rains.Length];
            var lakes = new Dictionary<int, int>();
            for (int i = rains.Length - 1; i >= 0; i--)
            {
                if(rains[i] == 0)
                    noRainDays.Insert(0, i);
                else
                {
                    if (lakes.ContainsKey(rains[i]))
                    {
                        if(noRainDays.Count == 0) return new int[0];
                        int day = noRainDays.BinarySearch(lakes[rains[i]]);
                        if(day == -1) return new int[0];
                        res[noRainDays[-(day + 1) - 1]] = rains[i];
                        noRainDays.RemoveAt(-(day + 1) - 1);
                    }
                    res[i] = -1;
                    lakes[rains[i]] = i;
                }
            }
            foreach (var day in noRainDays)
                res[day] = 1;
            return res;
        }
    }
}
