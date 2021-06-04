using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenTheLock
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] deadends = { "0201", "0101", "0102", "1212", "2002" };
            string target = "0202";
            Console.WriteLine(OpenLock(deadends, target));
        }
        static int OpenLock(string[] deadends, string target)
        {
            var set = new HashSet<string>();
            foreach (var deadend in deadends)
            {
                if (deadend == "0000") return -1;
                set.Add(deadend);
            }
            var queue = new Queue<KeyValuePair<string, int>>();
            var visit = new HashSet<string>();
            queue.Enqueue(new KeyValuePair<string, int>("0000", 0));
            visit.Add("0000");
            while (queue.Count != 0)
            {
                var cur = queue.Dequeue();
                var level = cur.Value;
                if (cur.Key == target) return level;
                for (int i = 0; i < 4; i++)
                {
                    var digit = cur.Key[i];
                    var up = cur.Key[i] == '9' ? '0' : (char)(digit + 1);
                    var down = cur.Key[i] == '0' ? '9' : (char)(digit - 1);
                    string numUp = cur.Key.Substring(0, i - 0) + up + cur.Key.Substring(i + 1, 3 - i);
                    string numDown = cur.Key.Substring(0, i - 0) + down + cur.Key.Substring(i + 1, 3 - i);
                    if (!visit.Contains(numUp) && set.Add(numUp)) queue.Enqueue(new KeyValuePair<string, int>(numUp, level + 1));
                    if (!visit.Contains(numDown) && set.Add(numDown)) queue.Enqueue(new KeyValuePair<string, int>(numDown, level + 1));
                }
            }
            return -1;
        }
    }
}
