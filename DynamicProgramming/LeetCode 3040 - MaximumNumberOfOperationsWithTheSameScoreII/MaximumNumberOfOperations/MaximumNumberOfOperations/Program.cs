int[] nums = { 3, 2, 1, 2, 3, 4 };
Console.WriteLine(MaxOperations(nums));

int MaxOperations(int[] nums)
{
    var dp = new int[nums.Length][];
    for (int i = 0; i < dp.Length; i++)
        dp[i] = new int[nums.Length];
    var op1 = 1 + DFS(nums, nums[0] + nums[1], 2, nums.Length - 1, dp);
    var op2 = 1 + DFS(nums, nums[^1] + nums[^2], 0, nums.Length - 3, dp);
    var op3 = 1 + DFS(nums, nums[0] + nums[^1], 1, nums.Length - 2, dp);
    return Math.Max(op1, Math.Max(op2, op3));
}

int DFS(int[] nums, int sum, int li, int hi, int[][] dp)
{
    if (hi <= li)
        return 0;
    if (hi - li == 1)
        return nums[li] + nums[hi] == sum ? 1 : 0;
    if (dp[li][hi] != 0)
        return dp[li][hi];
    var res = 0;
    if (nums[li] + nums[li + 1] == sum)
        res = Math.Max(res, 1 + DFS(nums, sum, li + 2, hi, dp));
    if (nums[hi] + nums[hi - 1] == sum)
        res = Math.Max(res, 1 + DFS(nums, sum, li, hi - 2, dp));
    if (nums[li] + nums[hi] == sum)
        res = Math.Max(res, 1 + DFS(nums, sum, li + 1, hi - 1, dp));
    return dp[li][hi] = res;
}