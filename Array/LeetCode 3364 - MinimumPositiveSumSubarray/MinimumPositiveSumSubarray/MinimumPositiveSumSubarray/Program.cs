int[] nums = { 4, 10 };
int l = 1, r = 1;
Console.WriteLine(MinimumSumSubarray(nums, l, r));
int MinimumSumSubarray(IList<int> nums, int l, int r)
{
    var prefix = new int[nums.Count];
    for (int i = 0; i < nums.Count; i++)
        prefix[i] = i == 0 ? nums[i] : nums[i] + prefix[i - 1];
    var res = int.MaxValue;
    for (int i = l - 1; i < prefix.Length; i++)
    {
        for (int j = Math.Max(0, i - r + 1); j <= i - l + 1; j++)
        {
            var sum = prefix[i] - (j == 0 ? 0 : prefix[j - 1]);
            if (sum > 0)
                res = Math.Min(res, sum);
        }
    }
    return res == int.MaxValue ? -1 : res;
}