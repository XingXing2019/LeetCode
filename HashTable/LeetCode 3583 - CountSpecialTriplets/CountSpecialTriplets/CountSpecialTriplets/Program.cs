int[] nums = { 6, 3, 6 };
Console.WriteLine(SpecialTriplets(nums));

int SpecialTriplets(int[] nums)
{
    long mod = 1_000_000_000 + 7, res = 0;
    var counts = new long[nums.Length];
    var before = new Dictionary<int, long>();
    var after = new Dictionary<int, long>();
    for (int i = 0; i < nums.Length; i++)
    {
        counts[i] = before.ContainsKey(nums[i] * 2) ? before[nums[i] * 2] : 0;
        if (!before.ContainsKey(nums[i]))
            before[nums[i]] = 0;
        before[nums[i]]++;
    }
    for (int i = nums.Length - 1; i >= 0; i--)
    {
        counts[i] *= after.ContainsKey(nums[i] * 2) ? after[nums[i] * 2] % mod : 0;
        if (!after.ContainsKey(nums[i]))
            after[nums[i]] = 0;
        after[nums[i]]++;
        res = (res + counts[i]) % mod;
    }
    return (int)res;
}