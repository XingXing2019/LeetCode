int[] prices = { 2, 1, 6, 1 };
Console.WriteLine(MinimumCoins(prices));

int MinimumCoins(int[] prices)
{
    var dp = new int[prices.Length][];
    dp[0] = new[] { prices[0], prices[0] };
    for (int i = 1; i < prices.Length; i++)
    {
        dp[i] = new int[2];
        var min = int.MaxValue;
        for (int j = i - 1; j + j + 1 >= i && j >= 0; j--)
            min = Math.Min(min, dp[j][0]);
        dp[i][0] = Math.Min(dp[i - 1][0], dp[i - 1][1]) + prices[i];
        dp[i][1] = min;
    }
    return Math.Min(dp[^1][0], dp[^1][1]);
}