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
            var queue = new Queue<string>();
            var visit = new HashSet<string>();
            queue.Enqueue("0000");
            visit.Add("0000");
            int level = -1;
            while (queue.Count != 0)
            {
                int count = queue.Count;
                level++;
                while (count != 0)
                {
                    var cur = queue.Dequeue();
                    if (cur == target) return level;
                    for (int i = 0; i < 4; i++)
                    {
                        var digit = cur[i];
                        var up = cur[i] == '9' ? '0' : (char) (digit + 1);
                        var down = cur[i] == '0' ? '9' : (char) (digit - 1);
                        string numUp = cur.Substring(0, i - 0) + up + cur.Substring(i + 1, 3 - i);
                        string numDown = cur.Substring(0, i - 0) + down + cur.Substring(i + 1, 3 - i);
                        if(!visit.Contains(numUp) && set.Add(numUp)) queue.Enqueue(numUp);
                        if(!visit.Contains(numDown) && set.Add(numDown)) queue.Enqueue(numDown);
                    }
                    count--;
                }
            }
            return -1;
        }
    }
}
