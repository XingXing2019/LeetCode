int MinXor(int[] nums, int k)
{
    var dp = new int[nums.Length + 1][];
    for (int i = 0; i < dp.Length; i++)
    {
        dp[i] = new int[k + 1];
        Array.Fill(dp[i], -1);
    }
    return DFS(nums, k, 0, dp);
}

int DFS(int[] nums, int k, int index, int[][] dp)
{
    if (k < 0) return int.MaxValue;
    if (k == 0)
        return index == nums.Length ? 0 : int.MaxValue;
    if (dp[index][k] != -1)
        return dp[index][k];
    int min = int.MaxValue, xor = 0;
    for (int i = index; i < nums.Length; i++)
    {
        xor ^= nums[i];
        min = Math.Min(min, Math.Max(xor, DFS(nums, k - 1, i + 1, dp)));
    }
    return dp[index][k] = min;
}