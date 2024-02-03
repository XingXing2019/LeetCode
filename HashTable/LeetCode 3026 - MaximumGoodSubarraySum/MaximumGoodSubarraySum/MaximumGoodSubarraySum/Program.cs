int[] nums = { 3, 3, 2 };
var k = 1;
Console.WriteLine(MaximumSubarraySum(nums, k));

long MaximumSubarraySum(int[] nums, int k)
{
    var prefix = new long[nums.Length];
    for (int i = 0; i < nums.Length; i++)
        prefix[i] = i == 0 ? nums[i] : nums[i] + prefix[i - 1];
    var dict = new Dictionary<int, long>();
    long res = long.MinValue;
    for (int i = 0; i < nums.Length; i++)
    {
        if (dict.ContainsKey(nums[i] + k))
            res = Math.Max(res, prefix[i] - dict[nums[i] + k]);
        if (dict.ContainsKey(nums[i] - k))
            res = Math.Max(res, prefix[i] - dict[nums[i] - k]);
        if (!dict.ContainsKey(nums[i]))
            dict[nums[i]] = long.MaxValue;
        dict[nums[i]] = Math.Min(dict[nums[i]], i == 0 ? 0 : prefix[i - 1]);
    }
    return res == long.MinValue ? 0 : res;
}