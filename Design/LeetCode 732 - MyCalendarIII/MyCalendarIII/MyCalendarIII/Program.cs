using System;
using System.Collections.Generic;

namespace MyCalendarIII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class MyCalendarThree
    {
        private SortedDictionary<int, int> timestamps;
        public MyCalendarThree()
        {
            timestamps = new SortedDictionary<int, int>();
        }

        public int Book(int start, int end)
        {
            timestamps[start] = timestamps.GetValueOrDefault(start, 0) + 1;
            timestamps[end] = timestamps.GetValueOrDefault(end, 0) - 1;
            int cur = 0, res = 0;
            foreach (var timestamp in timestamps.Values)
            {
                cur += timestamp;
                res = Math.Max(res, cur);
            }
            return res;

        }
    }
}
