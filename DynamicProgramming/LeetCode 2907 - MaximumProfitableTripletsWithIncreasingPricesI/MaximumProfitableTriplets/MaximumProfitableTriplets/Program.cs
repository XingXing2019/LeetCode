int[] prices = { 1, 2, 6, 8 };
int[] profits = { 9, 1, 4, 6 };
Console.WriteLine(MaxProfit(prices, profits));

int MaxProfit(int[] prices, int[] profits)
{
    var dp = (int[])profits.Clone();
    var res = -1;
    for (int i = 1; i < dp.Length; i++)
    {
        for (int j = 0; j < i; j++)
        {
            if (prices[i] <= prices[j]) continue;
            if (dp[j] != profits[j])
                res = Math.Max(res, profits[i] + dp[j]);
            dp[i] = Math.Max(dp[i], profits[i] + profits[j]);
        }
    }
    return res;
}