using System;

namespace PoorPigs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int PoorPigs(int buckets, int minutesToDie, int minutesToTest)
        {
            var tests = minutesToTest / minutesToDie + 1;
            return (int)Math.Ceiling(Math.Log(buckets, tests));
        }
    }
}
