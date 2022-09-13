using System;
using System.Collections.Generic;
using System.Linq;

namespace AlertUsingSameKeyCard
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] keyName = { "daniel", "daniel", "daniel", "luis", "luis", "luis", "luis" };
            string[] keyTime = { "10:00", "10:40", "11:00", "09:00", "11:00", "13:00", "15:00" };
            Console.WriteLine(AlertNames(keyName, keyTime));
        }

        public static IList<string> AlertNames(string[] keyName, string[] keyTime)
        {
            var dict = new Dictionary<string, List<int>>();
            for (int i = 0; i < keyName.Length; i++)
            {
                if (!dict.ContainsKey(keyName[i]))
                    dict[keyName[i]] = new List<int>();
                dict[keyName[i]].Add(GetTime(keyTime[i]));
            }
            var res = new List<string>();
            foreach (var name in dict.Keys)
            {
                var times = dict[name].OrderBy(x => x).ToList();
                for (int i = 2; i < times.Count; i++)
                {
                    if (times[i] - times[i - 2] > 60) continue;
                    res.Add(name);
                    break;
                }
            }
            return res.OrderBy(x => x).ToList();
        }

        private static int GetTime(string time)
        {
            var parts = time.Split(':');
            return int.Parse(parts[0]) * 60 + int.Parse(parts[1]);
        }
    }
}
