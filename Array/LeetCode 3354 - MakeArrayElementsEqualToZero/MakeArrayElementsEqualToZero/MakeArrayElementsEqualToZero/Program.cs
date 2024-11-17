int CountValidSelections(int[] nums)
{
    var prefix = new int[nums.Length];
    var suffix = new int[nums.Length];
    for (int i = 0; i < nums.Length; i++)
    {
        prefix[i] = i == 0 ? nums[i] : nums[i] + prefix[i - 1];
        suffix[^(i + 1)] = i == 0 ? nums[^(i + 1)] : nums[^(i + 1)] + suffix[^i];
    }
    var res = 0;
    for (int i = 0; i < nums.Length; i++)
    {
        if (nums[i] != 0)
            continue;
        if (Math.Abs(prefix[i] - suffix[i]) == 1)
            res++;
        if (prefix[i] == suffix[i])
            res += 2;
    }
    return res;
}