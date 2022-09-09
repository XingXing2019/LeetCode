using System;
using System.Collections.Generic;

namespace ExclusiveTimeOfFunctions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var n = 2;
            var logs = new[] { "0:start:0", "1:start:2", "1:end:5", "0:end:6" };
            Console.WriteLine(ExclusiveTime(n, logs));
        }

        public class Function
        {
            public int id;
            public int timestamp;
            public string type;

            public Function(int id, int timestamp, string type)
            {
                this.id = id;
                this.timestamp = timestamp;
                this.type = type;
            }
        }

        public static int[] ExclusiveTime(int n, IList<string> logs)
        {
            var cpu = new Stack<Function>();
            var times = new Dictionary<int, int>();
            var res = new int[n];
            foreach (var log in logs)
            {
                var function = ReadLog(log);
                if (!times.ContainsKey(function.id))
                    times[function.id] = 0;
                if (function.type == "start")
                {
                    if (cpu.Count != 0)
                        times[cpu.Peek().id] += function.timestamp - cpu.Peek().timestamp;
                    cpu.Push(function);
                }
                else
                {
                    times[function.id] += function.timestamp - cpu.Pop().timestamp + 1;
                    if (cpu.Count != 0)
                        cpu.Peek().timestamp = function.timestamp + 1;
                }
            }
            foreach (var id in times.Keys)
                res[id] = times[id];
            return res;
        }

        public static Function ReadLog(string log)
        {
            var parts = log.Split(':');
            var id = int.Parse(parts[0]);
            var type = parts[1];
            var timestamp = int.Parse(parts[2]);
            return new Function(id, timestamp, type);
        }
    }
}
