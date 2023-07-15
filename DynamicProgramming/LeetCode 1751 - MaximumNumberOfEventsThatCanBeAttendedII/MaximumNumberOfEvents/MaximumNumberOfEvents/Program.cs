using System;

namespace MaximumNumberOfEvents
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] events = new[]
            {
                new[] { 1, 2, 4 },
                new[] { 3, 4, 3 },
                new[] { 2, 3, 1 }
            };
            var k = 2;
            Console.WriteLine(MaxValue(events, k));
        }

        public static int MaxValue(int[][] events, int k)
        {
            Array.Sort(events, (a, b) => a[1] - b[1]);
            var dp = new int[events.Length + 1][];
            for (int i = 0; i < dp.Length; i++)
                dp[i] = new int[k + 1];
            for (int i = 0; i < events.Length; i++)
            {
                var index = BinarySearch(events, events[i][0], 0, i);
                for (int j = 1; j <= k; j++)
                {
                    dp[i + 1][j] = Math.Max(dp[i][j], dp[index][j - 1] + events[i][2]);
                }
            }
            var res = 0;
            for (int i = 0; i < dp.Length; i++)
                res = Math.Max(res, dp[i][k]);
            return res;
        }

        public static int BinarySearch(int[][] events, int start, int li, int hi)
        {
            while (li <= hi)
            {
                var mid = li + (hi - li) / 2;
                if (start > events[mid][1])
                    li = mid + 1;
                else
                    hi = mid - 1;
            }
            return li;
        }
    }
}
