using System;

namespace FindMinimumTimeToFinishAllJobsII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int MinimumTime(int[] jobs, int[] workers)
        {
            Array.Sort(jobs);
            Array.Sort(workers);
            var res = 0;
            for (int i = 0; i < jobs.Length; i++)
                res = Math.Max(res, (int)Math.Ceiling((double)jobs[i] / workers[i]));
            return res;
        }
    }
}
