using System;

namespace DetermineIfACellIsReachableAtAGivenTime
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public bool IsReachableAtTime(int sx, int sy, int fx, int fy, int t)
        {
            if (sx == fx && sy == fy)
                return t != 1;
            var dis = Math.Max(Math.Abs(sx - fx), Math.Abs(sy - fy));
            return dis <= t;
        }
    }
}
