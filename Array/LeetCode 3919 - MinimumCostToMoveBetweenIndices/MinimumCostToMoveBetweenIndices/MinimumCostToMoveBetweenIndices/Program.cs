int[] nums = { -5, -2, 3 };
int[][] queries = new int[][]
{
    new[] { 0, 2 },
    new[] { 2, 0 },
    new[] { 1, 2 },
};
Console.WriteLine(MinCost(nums, queries));

int[] MinCost(int[] nums, int[][] queries)
{
    var closest = new int[nums.Length];
    for (int i = 0; i < nums.Length; i++)
    {
        var pre = i == 0 ? int.MaxValue : Math.Abs(nums[i] - nums[i - 1]);
        var post = i == nums.Length - 1 ? int.MaxValue : Math.Abs(nums[i] - nums[i + 1]);
        closest[i] = pre <= post ? i - 1 : i + 1;
    }
    var prefix = new long[nums.Length];
    var suffix = new long[nums.Length];
    for (int i = 0; i < nums.Length; i++)
    {
        var p = i == nums.Length - 1 ? int.MaxValue : closest[i] == i + 1 ? 1 : Math.Abs(nums[i] - nums[i + 1]);
        var s = i == nums.Length - 1 ? int.MaxValue : closest[^(i + 1)] == nums.Length - i - 2 ? 1 : Math.Abs(nums[^(i + 1)] - nums[^(i + 2)]);
        prefix[i] = i == 0 ? p : p + prefix[i - 1];
        suffix[^(i + 1)] = i == 0 ? s : s + suffix[^i];
    }
    var res = new int[queries.Length];
    for (int i = 0; i < queries.Length; i++)
    {
        int l = queries[i][0], r = queries[i][1];
        if (l == r) continue;
        res[i] = r > l ? (int)(prefix[r - 1] - (l == 0 ? 0 : prefix[l - 1])) : (int)(suffix[r + 1] - (l == nums.Length - 1 ? 0 : suffix[l + 1]));
    }
    return res;
}