using System;

namespace AngleBetweenHandsOfAClock
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static double AngleClock(int hour, int minutes)
        {
            double hourPos = hour % 12 * 30 + (double) minutes / 60 * 30;
            double minPos = minutes * 6;
            double res = Math.Abs(hourPos - minPos) > 180
                ? 360 - Math.Abs(hourPos - minPos)
                : Math.Abs(hourPos - minPos);
            return res;
        }
    }
}
