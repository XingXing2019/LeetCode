using System;
using System.Collections.Generic;

namespace MyCalendarII
{
    
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    public class MyCalendarTwo
    {
        class Event : IComparable
        {
            public int start;
            public int end;
            public Event(int start, int end)
            {
                this.start = start;
                this.end = end;
            }

            public int CompareTo(object obj)
            {
                var e = obj as Event;
                return start == e.start ? end < e.end ? -1 : 1 : start < e.start ? -1 : 1;
            }
        }

        private SortedSet<Event> set;
        public MyCalendarTwo()
        {
            set = new SortedSet<Event>();
        }

        public bool Book(int start, int end)
        {
            var duplicate = new List<Event>();
            foreach (var e in set)
            {
                if (e.start <= start && start < e.end || e.start < end && end <= e.end)
                    duplicate.Add(e);
                else if (start <= e.start && end >= e.end || e.start <= start && end <= e.end)
                    duplicate.Add(e);
            }
            for (int i = 1; i < duplicate.Count; i++)
            {
                if (duplicate[i].start < duplicate[i - 1].end)
                    return false;
            }
            set.Add(new Event(start, end));
            return true;
        }
    }
}
