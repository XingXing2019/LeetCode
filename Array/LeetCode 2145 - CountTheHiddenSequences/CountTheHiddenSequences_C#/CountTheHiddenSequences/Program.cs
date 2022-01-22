using System;

namespace CountTheHiddenSequences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int NumberOfArrays(int[] differences, int lower, int upper)
        {
            int min = 0, max = 0, cur = 0;
            foreach (var difference in differences)
            {
                cur += difference;
                min = Math.Min(min, cur);
                max = Math.Max(max, cur);
            }
            return Math.Max(0, Math.Min(upper - min, upper - max) - Math.Max(lower - min, lower - max) + 1);
        }
    }
}
