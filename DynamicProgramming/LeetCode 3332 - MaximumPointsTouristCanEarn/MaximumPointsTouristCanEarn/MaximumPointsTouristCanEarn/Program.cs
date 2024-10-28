int n = 1, k = 2;
int[][] stayScore = new[]
{
    new[] { 1 },
    new[] { 2 },
};
int[][] travelScore = new int[][]
{
    new[] { 0 }
};

Console.WriteLine(MaxScore(n, k, stayScore, travelScore));

int MaxScore(int n, int k, int[][] stayScore, int[][] travelScore)
{
    var dp = new int[k][];
    for (int i = 0; i < k; i++)
    {
        dp[i] = new int[n];
        Array.Fill(dp[i], -1);
    }
    var res = 0;
    for (int i = 0; i < n; i++)
        res = Math.Max(res, DFS(i, 0, n, k, stayScore, travelScore, dp));
    return res;
}

int DFS(int cur, int day, int n, int k, int[][] stayScore, int[][] travelScore, int[][] dp)
{
    if (day >= k) return 0;
    if (dp[day][cur] != -1) return dp[day][cur];
    var stay = stayScore[day][cur] + DFS(cur, day + 1, n, k, stayScore, travelScore, dp);
    var travel = 0;
    for (int i = 0; i < n; i++)
        travel = Math.Max(travel, travelScore[cur][i] + DFS(i, day + 1, n, k, stayScore, travelScore, dp));
    return dp[day][cur] = Math.Max(stay, travel);
}