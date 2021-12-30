using System;
using System.Linq;

namespace VideoStitching
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] clips =
            {
                new[] { 0, 0 },
                new[] { 2, 2 },
                new[] { 1, 3 },
            };
            var time = 1;
            Console.WriteLine(VideoStitching(clips, time));
        }
        public static int VideoStitching(int[][] clips, int time)
        {
            clips = clips.OrderBy(x => x[0]).ThenByDescending(x => x[1]).ToArray();
            if (clips[0][0] != 0) return -1;
            if (clips[0][1] >= time) return 1;
            var dp = new int[clips.Length][];
            for (int i = 0; i < dp.Length; i++)
                dp[i] = new int[2];
            dp[0] = new[] { 1, clips[0][1] };
            for (int i = 1; i < dp.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (clips[i][0] > dp[j][1]) continue;
                    dp[i] = new[] { dp[j][0] + 1, Math.Max(dp[j][1], clips[i][1]) };
                    if (dp[i][1] >= time)
                        return dp[i][0];
                    break;
                }
            }
            return -1;
        }
    }
}
