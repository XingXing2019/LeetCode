int[] nums = { 1, 5, 9, 2 };
var k = 2;
Console.WriteLine(MaximumLength(nums, k));
int MaximumLength(int[] nums, int k)
{
    var res = 0;
    var dp = new Dictionary<int, int>[nums.Length];
    for (int i = 0; i < dp.Length; i++)
        dp[i] = new Dictionary<int, int>();
    for (int i = 1; i < nums.Length; i++)
    {
        for (int j = 0; j < i; j++)
        {
            var mod = (nums[i] + nums[j]) % k;
            dp[i][mod] = 1;
            if (dp[j].ContainsKey(mod))
                dp[i][mod] = Math.Max(dp[i][mod], dp[j][mod] + 1);
            res = Math.Max(res, dp[i][mod] + 1);
        }
    }
    return res;
}