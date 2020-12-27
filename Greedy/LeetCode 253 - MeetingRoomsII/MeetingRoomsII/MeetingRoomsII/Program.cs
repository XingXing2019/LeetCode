using System;
using System.Collections.Generic;
using System.Linq;

namespace MeetingRoomsII
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int MinMeetingRooms_Array(int[][] intervals)
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
        public int MinMeetingRooms_Dictionary(int[][] intervals)
        {
            var schedules = new Dictionary<int, int>();
            foreach (var interval in intervals)
            {
                if (!schedules.ContainsKey(interval[0]))
                    schedules[interval[0]] = 0;
                schedules[interval[0]]++;
                if (!schedules.ContainsKey(interval[1]))
                    schedules[interval[1]] = 0;
                schedules[interval[1]]--;
            }
            var rooms = schedules.OrderBy(x => x.Key).Select(x => x.Value);
            int res = 0, temp = 0;
            foreach (var room in rooms)
            {
                temp += room;
                res = Math.Max(res, temp);
            }
            return res;
        }
    }
}
