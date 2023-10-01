int[] nums = { 12, 6, 1, 2, 7 };
Console.WriteLine(MaximumTripletValue(nums));

long MaximumTripletValue(int[] nums)
{
    var prefixMax = new long[nums.Length];
    var suffixMax = new long[nums.Length];
    long prefix = long.MinValue, suffix = long.MinValue, res = 0;
    for (int i = 0; i < nums.Length; i++)
    {
        prefixMax[i] = prefix;
        prefix = Math.Max(prefix, nums[i]);
        suffixMax[^(i + 1)] = suffix;
        suffix = Math.Max(suffix, nums[^(i + 1)]);
    }
    for (int i = 1; i < nums.Length - 1; i++)
        res = Math.Max(res, (prefixMax[i] - nums[i]) * suffixMax[i]);
    return res;
}