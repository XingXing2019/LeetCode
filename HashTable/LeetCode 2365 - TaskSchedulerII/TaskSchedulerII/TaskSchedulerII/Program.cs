using System;
using System.Collections.Generic;

namespace TaskSchedulerII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public long TaskSchedulerII(int[] tasks, int space)
        {
            var dict = new Dictionary<int, long>();
            long index = 0;
            foreach (var task in tasks)
            {
                index++;
                if (dict.ContainsKey(task))
                {
                    var diff = index - dict[task] - 1;
                    if (diff < space)
                        index += space - diff;
                }
                dict[task] = index;
            }
            return index;
        }
    }
}
