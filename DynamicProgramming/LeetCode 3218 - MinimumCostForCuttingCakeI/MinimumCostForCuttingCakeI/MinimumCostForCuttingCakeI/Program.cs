int m = 3, n = 2;
int[] horizontalCut = { 1, 3 };
int[] verticalCut = { 5 };
Console.WriteLine(MinimumCost(m, n, horizontalCut, verticalCut));

int MinimumCost(int m, int n, int[] horizontalCut, int[] verticalCut)
{
    var dp = new int[21][][][];
    for (int i = 0; i < dp.Length; i++)
    {
        dp[i] = new int[21][][];
        for (int j = 0; j < dp[i].Length; j++)
        {
            dp[i][j] = new int[21][];
            for (int k = 0; k < dp[i][j].Length; k++)
            {
                dp[i][j][k] = new int[21];
                Array.Fill(dp[i][j][k], -1);
            }
        }
    }
    return DFS(0, m - 1, 0, n - 1, horizontalCut, verticalCut, dp);
}

int DFS(int hLi, int hHi, int vLi, int vHi, int[] horizontalCut, int[] verticalCut, int[][][][] dp)
{
    if (hLi == hHi && vLi == vHi)
        return 0;
    if (dp[hLi][hHi][vLi][vHi] != -1)
        return dp[hLi][hHi][vLi][vHi];
    var ans = int.MaxValue;
    for (int i = hLi; i < hHi; i++)
    {
        var up = DFS(hLi, i, vLi, vHi, horizontalCut, verticalCut, dp);
        var down = DFS(i + 1, hHi, vLi, vHi, horizontalCut, verticalCut, dp);
        ans = Math.Min(ans, horizontalCut[i] + up + down);
    }

    for (int i = vLi; i < vHi; i++)
    {
        var left = DFS(hLi, hHi, vLi, i, horizontalCut, verticalCut, dp);
        var right = DFS(hLi, hHi, i + 1, vHi, horizontalCut, verticalCut, dp);
        ans = Math.Min(ans, verticalCut[i] + left + right);
    }
    dp[hLi][hHi][vLi][vHi] = ans;
    return ans;
}