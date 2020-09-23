using System;
using System.Linq;

namespace MeetingRoomsII
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int MinMeetingRooms(int[][] intervals)
        {
            if (intervals.Length == 0) return 0;
            var last = intervals.Max(x => x[1]);
            var schedule = new int[last + 1];
            foreach (var interval in intervals)
            {
                schedule[interval[0]] += 1;
                schedule[interval[1]] -= 1;
            }
            int res = 0, rooms = 0;
            for (int i = 0; i < schedule.Length; i++)
            {
                rooms += schedule[i];
                res = Math.Max(res, rooms);
            }
            return res;
        }
    }
}
