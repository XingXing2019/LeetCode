using System;

namespace StringCompressionII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var s = "aabbaa";
            var k = 2;
            Console.WriteLine(GetLengthOfOptimalCompression(s, k));
        }

        public static int GetLengthOfOptimalCompression(string s, int k)
        {
            var dp = new int[s.Length][];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new int[k + 1];
                Array.Fill(dp[i], -1);
            }
            return DFS(s, 0, k, dp);
        }

        public static int DFS(string s, int index, int k, int[][] dp)
        {
            if (k < 0) return s.Length;
            if (index + k >= s.Length) return 0;
            if (dp[index][k] != -1) return dp[index][k];
            var res = DFS(s, index + 1, k - 1, dp);
            int len = 0, same = 0, diff = 0;
            for (int j = index; j < s.Length && diff <= k; j++)
            {
                if (s[index] == s[j])
                {
                    same++;
                    if (same == 1 || same == 2 || same == 10 || same == 100)
                        len++;
                }
                else
                    diff++;
                res = Math.Min(res, len + DFS(s, j + 1, k - diff, dp));
            }
            return dp[index][k] = res;
        }

        public static int GetLengthOfOptimalCompression_MemoryDP(string s, int k)
        {
            var dp = new int[101][][][];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new int[27][][];
                for (int j = 0; j < dp[i].Length; j++)
                {
                    dp[i][j] = new int[101][];
                    for (int l = 0; l < dp[i][j].Length; l++)
                    {
                        dp[i][j][l] = new int[101];
                        Array.Fill(dp[i][j][l], -1);
                    }
                }
            }
            return DFS_MemoryDP(s, 0, 26, 0, k, dp);
        }

        public static int DFS_MemoryDP(string s, int index, int last, int len, int k, int[][][][] dp)
        {
            if (k < 0) return int.MaxValue;
            if (index + k >= s.Length) return 0;
            if (dp[index][last][len][k] != -1)
                return dp[index][last][len][k];
            var res = 0;
            if (s[index] - 'a' == last)
            {
                var carry = len == 1 || len == 9 || len == 99 ? 1 : 0;
                res = carry + DFS_MemoryDP(s, index + 1, last, len + 1, k, dp);
            }
            else
            {
                var keep = DFS_MemoryDP(s, index + 1, s[index] - 'a', 1, k, dp);
                var remove = DFS_MemoryDP(s, index + 1, last, len, k - 1, dp);
                res = Math.Min(1 + keep, remove);
            }
            return dp[index][last][len][k] = res;
        }
    }
}
