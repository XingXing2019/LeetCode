using System;

namespace CountDaysSpentTogether
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int CountDaysTogether(string arriveAlice, string leaveAlice, string arriveBob, string leaveBob)
        {
            int[] days = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            for (int i = 1; i < days.Length; i++)
                days[i] += days[i - 1];
            var alice = new int[] { GetDate(days, arriveAlice), GetDate(days, leaveAlice) };
            var bob = new int[] { GetDate(days, arriveBob), GetDate(days, leaveBob) };
            if (alice[1] < bob[0] || bob[1] < alice[0])
                return 0;
            return Math.Min(alice[1], bob[1]) - Math.Max(alice[0], bob[0]) + 1;
        }

        public int GetDate(int[] days, string date)
        {
            var parts = date.Split('-');
            var month = int.Parse(parts[0]);
            var day = int.Parse(parts[1]);
            return days[month - 1] + day;
        }
    }
}
