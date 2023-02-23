using System;

namespace PalindromeRemoval
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 16, 13, 13, 10, 12 };
            Console.WriteLine(MinimumMoves(arr));
        }

        public static int MinimumMoves(int[] arr)
        {
            var dp = new int[arr.Length][];
            for (int i = 0; i < dp.Length; i++)
                dp[i] = new int[arr.Length];
            return DFS(arr, dp, 0, arr.Length - 1);
        }

        public static int DFS(int[] arr, int[][] dp, int l, int r)
        {
            if (l == r) return 1;
            if (l > r) return 0;
            if (dp[l][r] != 0) return dp[l][r];
            var res = int.MaxValue;
            for (int i = l + 1; i <= r; i++)
            {
                if (arr[l] != arr[i]) continue;
                var left = l == i - 1 ? 1 : DFS(arr, dp, l + 1, i - 1);
                var right = DFS(arr, dp, i + 1, r);
                res = Math.Min(res, left + right);
            }
            res = Math.Min(res, 1 + DFS(arr, dp, l + 1, r));
            return dp[l][r] = res;
        }
    }
}
