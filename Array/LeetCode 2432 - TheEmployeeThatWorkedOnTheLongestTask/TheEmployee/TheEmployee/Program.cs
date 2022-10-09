using System;

namespace TheEmployee
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int HardestWorker(int n, int[][] logs)
        {
            int res = logs[0][0], max = logs[0][1];
            for (int i = 1; i < logs.Length; i++)
            {
                var time = logs[i][1] - logs[i - 1][1];
                if (time > max || (time == max && logs[i][0] < res))
                    res = logs[i][0];
                max = Math.Max(max, time);
            }
            return res;
        }
    }
}
