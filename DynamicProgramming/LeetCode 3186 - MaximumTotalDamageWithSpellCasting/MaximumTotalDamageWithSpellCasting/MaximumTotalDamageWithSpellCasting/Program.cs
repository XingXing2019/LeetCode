int[] power = { 1, 1, 3, 4 };
Console.WriteLine(MaximumTotalDamage(power));

long MaximumTotalDamage(int[] power)
{
    Array.Sort(power);
    var freq = power.GroupBy(x => x).ToDictionary(x => (long)x.Key, x => x.Count());
    var uniquePower = freq.Keys.ToList();
    var dp = new long[uniquePower.Count];
    Array.Fill(dp, -1);
    return DFS(uniquePower, 0, freq, dp);
}

long DFS(List<long> uniquePower, int index, Dictionary<long, int> freq, long[] dp)
{
    if (index >= uniquePower.Count) return 0;
    if (dp[index] != -1) return dp[index];
    var skip = DFS(uniquePower, index + 1, freq, dp);
    var nextIndex = index;
    while (nextIndex < uniquePower.Count && uniquePower[nextIndex] - uniquePower[index] <= 2)
        nextIndex++;
    var take = uniquePower[index] * freq[uniquePower[index]] + DFS(uniquePower, nextIndex, freq, dp);
    return dp[index] = Math.Max(skip, take);
}