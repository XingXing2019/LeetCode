var n = 4;
int[] nums = { 1, 2, 3, 4 };
Console.WriteLine(ClimbStairs(n, nums));

int ClimbStairs(int n, int[] costs)
{
    var dp = new int[n + 1];
    for (int i = 1; i < dp.Length; i++)
    {
        var min = int.MaxValue;
        for (int j = 1; j <= 3; j++)
        {
            if (i - j < 0) continue;
            min = Math.Min(min, costs[i - j] + j * j + dp[i - j]);
        }
        dp[i] = min;
    }
    return dp[^1];
}