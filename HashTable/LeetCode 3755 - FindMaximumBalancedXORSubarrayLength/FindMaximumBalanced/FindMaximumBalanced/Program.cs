int MaxBalancedSubarray(int[] nums)
{
    int diff = 0, xor = 0, res = 0;
    var dict = new Dictionary<(int, int), int> { { (diff, xor), -1 } };
    for (int i = 0; i < nums.Length; i++)
    {
        diff += nums[i] % 2 == 0 ? 1 : -1;
        xor ^= nums[i];
        if (dict.ContainsKey((diff, xor)))
            res = Math.Max(res, i - dict[(diff, xor)]);
        else
            dict[(diff, xor)] = i;
    }
    return res;
}