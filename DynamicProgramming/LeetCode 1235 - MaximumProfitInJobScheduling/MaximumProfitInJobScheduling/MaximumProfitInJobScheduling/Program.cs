using System;
using System.Linq;

namespace MaximumProfitInJobScheduling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] startTime = { 24, 7, 6, 18 };
            int[] endTime = { 27, 20, 20, 19 };
            int[] profit = { 1, 4, 5, 9 };
            Console.WriteLine(JobScheduling(startTime, endTime, profit));
        }

        public static int JobScheduling(int[] startTime, int[] endTime, int[] profit)
        {
            var jobs = new int[startTime.Length][];
            for (int i = 0; i < jobs.Length; i++)
                jobs[i] = new[] { startTime[i], endTime[i], profit[i] };
            jobs = jobs.OrderBy(x => x[1]).ToArray();
            var dp = new int[startTime.Length];
            dp[0] = jobs[0][2];
            for (int i = 1; i < dp.Length; i++)
            {
                var index = BinarySearch(jobs, 0, i - 1, jobs[i][0]);
                var max = index >= 0 ? dp[index] : 0;
                dp[i] = Math.Max(dp[i - 1], max + jobs[i][2]);
            }
            return dp[^1];
        }

        public static int BinarySearch(int[][] jobs, int li, int hi, int target)
        {
            while (li <= hi)
            {
                var mid = li + (hi - li) / 2;
                if (jobs[mid][1] <= target)
                    li = mid + 1;
                else
                    hi = mid - 1;
            }
            return hi;
        }
    }
}
