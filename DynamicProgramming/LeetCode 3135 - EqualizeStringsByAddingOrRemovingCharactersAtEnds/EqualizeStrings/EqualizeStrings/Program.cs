string initial = "ax", target = "abx";
Console.WriteLine(MinOperations(initial, target));

int MinOperations(string initial, string target)
{
    var dp = new int[1001][];
    for (int i = 0; i < dp.Length; i++)
    {
        dp[i] = new int[1001];
        Array.Fill(dp[i], -1);
    }
    var max = 0;
    DFS(initial, target, 0, 0, dp, ref max);
    return initial.Length + target.Length - max * 2;
}

int DFS(string initial, string target, int p1, int p2, int[][] dp, ref int max)
{
    if (p1 >= initial.Length || p2 >= target.Length)
        return 0;
    if (dp[p1][p2] != -1)
        return dp[p1][p2];
    var common = 0;
    if (initial[p1] == target[p2])
        common = 1 + DFS(initial, target, p1 + 1, p2 + 1, dp, ref max);
    max = Math.Max(max, common);
    DFS(initial, target, p1 + 1, p2, dp, ref max);
    DFS(initial, target, p1, p2 + 1, dp, ref max);
    return dp[p1][p2] = common;
}