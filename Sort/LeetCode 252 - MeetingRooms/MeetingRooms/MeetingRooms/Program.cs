using System;
using System.Linq;

namespace MeetingRooms
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static bool CanAttendMeetings(int[][] intervals)
        {
            if (intervals.Length == 1) return true;
            intervals = intervals.OrderBy(x => x[0]).ToArray();
            for (int i = 1; i < intervals.Length; i++)
            {
                if (intervals[i][0] < intervals[i - 1][1])
                    return false;
            }
            return true;
        }
    }
}
