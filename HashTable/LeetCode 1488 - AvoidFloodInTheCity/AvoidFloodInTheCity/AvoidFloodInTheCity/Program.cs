using System;
using System.Collections.Generic;

namespace AvoidFloodInTheCity
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rains = { 1, 2, 0, 2, 3, 0, 1 };
            Console.WriteLine(AvoidFlood(rains));
        }
        static int[] AvoidFlood(int[] rains)
        {
            var lakes = new Dictionary<int, int>();
            var result = new int[rains.Length];
            var noRainDays = new List<int>();
            for (int i = rains.Length - 1; i >= 0; i--)
            {
                if (rains[i] != 0)
                {
                    if (lakes.ContainsKey(rains[i]))
                    {
                        bool found = false;
                        for (int j = 0; j < noRainDays.Count; j++)
                        {
                            if (lakes[rains[i]] > noRainDays[j])
                            {
                                result[noRainDays[j]] = rains[i];
                                noRainDays.RemoveAt(j);
                                found = true;
                                break;
                            }
                        }
                        if (!found) return new int[0];
                    }
                    result[i] = -1;
                    lakes[rains[i]] = i;
                }
                else
                    noRainDays.Add(i);
            }
            for (int j = 0; j < noRainDays.Count; j++)
                result[noRainDays[j]] = 1;
            return result;
        }
    }
}
