int[] FindXSum(int[] nums, int k, int x)
{
    var res = new int[nums.Length - k + 1];
    var freq = new Dictionary<int, int>();
    for (int i = 0; i < k; i++)
        freq[nums[i]] = freq.GetValueOrDefault(nums[i], 0) + 1;
    for (int i = k; i < nums.Length; i++)
    {
        res[i - k] = freq.OrderByDescending(x => x.Value).ThenByDescending(x => x.Key).Take(x).Sum(x => x.Key * x.Value);
        freq[nums[i]] = freq.GetValueOrDefault(nums[i], 0) + 1;
        freq[nums[i - k]]--;
        if (freq[nums[i - k]] == 1)
            freq.Remove(nums[i - k]);
    }
    res[^1] = freq.OrderByDescending(x => x.Value).ThenByDescending(x => x.Key).Take(x).Sum(x => x.Key * x.Value);
    return res;
}