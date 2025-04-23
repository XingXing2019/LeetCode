int SubarraySum(int[] nums)
{
    var prefix = new int[nums.Length];
    for (int i = 0; i < nums.Length; i++)
        prefix[i] = i == 0 ? nums[i] : nums[i] + prefix[i - 1];
    var res = 0;
    for (int i = 0; i < nums.Length; i++)
    {
        var start = Math.Max(0, i - nums[i]);
        res += start == 0 ? prefix[i] : prefix[i] - prefix[start - 1];
    }
    return res;
}