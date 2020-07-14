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
            var hourPos = hour % 12 * 30 + (double) minutes / 60 * 30;
            var minPos = (double) minutes * 6;
            return Math.Abs(hourPos - minPos) > 180 ? 
                360 - Math.Abs(hourPos - minPos) :
                Math.Abs(hourPos - minPos);
        }
    }
}
