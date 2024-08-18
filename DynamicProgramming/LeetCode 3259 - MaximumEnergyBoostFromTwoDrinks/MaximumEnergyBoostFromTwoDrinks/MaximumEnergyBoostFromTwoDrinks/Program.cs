int[] energyDrinkA = { 4, 1, 1 };
int[] energyDrinkB = { 1, 1, 3 };
Console.WriteLine(MaxEnergyBoost(energyDrinkA, energyDrinkB));

long MaxEnergyBoost(int[] energyDrinkA, int[] energyDrinkB)
{
    var dp = new long[energyDrinkA.Length][];
    dp[0] = new long[] { energyDrinkA[0], energyDrinkB[0] };
    for (int i = 1; i < dp.Length; i++)
    {
        var a = energyDrinkA[i] + Math.Max(dp[i - 1][0], i == 1 ? 0 : dp[i - 2][1]);
        var b = energyDrinkB[i] + Math.Max(dp[i - 1][1], i == 1 ? 0 : dp[i - 2][0]);
        dp[i] = new[] { a, b };
    }
    return Math.Max(dp[^1][0], dp[^1][1]);
}