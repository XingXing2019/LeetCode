using System;
using System.Collections.Generic;
using System.Linq;

namespace VideoStitching
{
    class Program
    {
        static void Main(string[] args)
        {
            int T = 10;
            int[][] clips = new int[12][];
            clips[0] = new int[] { 0, 1 };
            clips[1] = new int[] { 6, 8 };
            clips[2] = new int[] { 0, 2 };
            clips[3] = new int[] { 5, 6 };
            clips[4] = new int[] { 0, 4 };
            clips[5] = new int[] { 0, 3 };
            clips[6] = new int[] { 6, 7 };
            clips[7] = new int[] { 2, 6 };
            clips[8] = new int[] { 3, 4 };
            clips[9] = new int[] { 4, 5 };
            clips[10] = new int[] { 5, 7 };
            clips[11] = new int[] { 6, 9 };

            Console.WriteLine(VideoStitching(clips, T));
        }
        public int VideoStitching(int[][] clips, int time)
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
