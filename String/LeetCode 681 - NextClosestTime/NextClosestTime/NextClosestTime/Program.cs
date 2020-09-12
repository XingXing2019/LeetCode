using System;
using System.Collections.Generic;
using System.Linq;

namespace NextClosestTime
{
    class Program
    {
        static void Main(string[] args)
        {
            var time = "19:34";
            Console.WriteLine(NextClosestTime(time));
        }
        static string NextClosestTime(string time)
        {
            var digits = new HashSet<char>();
            foreach (var digit in time)
                digits.Add(digit);
            var oldTime = new DateTime(2020, 09, 12, int.Parse(time.Substring(0, 2)), int.Parse(time.Substring(3, 2)), 0);
            while (true)
            {
                var newTime = oldTime.AddMinutes(1);
                if (newTime.ToString("HH:mm").All(x => digits.Contains(x)))
                    return newTime.ToString("HH:mm");
                oldTime = newTime;
            }
        }
    }
}
