using System;
using System.Collections.Generic;
using System.Linq;

namespace MyCalendarI
{
    class Program
    {
        static void Main(string[] args)
        {
            var calendar = new MyCalendar();
            Console.WriteLine(calendar.Book(47, 50));
            Console.WriteLine(calendar.Book(33, 41));
            Console.WriteLine(calendar.Book(39, 45));
            //Console.WriteLine(calendar.Book(25, 30));
            //Console.WriteLine(calendar.Book(35, 45));
            //Console.WriteLine(calendar.Book(40, 50));
        }
    }
    public class MyCalendar
    {
        private List<int[]> intervals;
        public MyCalendar()
        {
            intervals = new List<int[]>();
        }

        public bool Book(int start, int end)
        {
            if (intervals.Count <= 1)
            {
                int count = intervals.Count;
                if (intervals.Count == 0 || start >= intervals[0][1])
                    intervals.Add(new []{start, end});
                else if (end <= intervals[0][0])
                    intervals.Insert(0, new []{start, end});
                return intervals.Count > count;
            }
            for (int i = 0; i <= intervals.Count; i++)
            {
                var pre = i == 0 ? null : intervals[i - 1];
                var pro = i == intervals.Count ? null : intervals[i];
                if (start >= (pre?[1] ?? 0) && end <= (pro?[0] ?? 1_000_000_000))
                {
                    intervals.Insert(i, new []{start, end});
                    return true;
                }
            }
            return false;
        }
    }
}
