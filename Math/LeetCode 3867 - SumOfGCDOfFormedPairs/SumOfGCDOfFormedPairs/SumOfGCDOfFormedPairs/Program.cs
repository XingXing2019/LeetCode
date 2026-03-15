long GcdSum(int[] nums)
{
    var max = nums[0];
    var prefixMax = new long[nums.Length];
    for (int i = 0; i < nums.Length; i++)
    {
        max = Math.Max(max, nums[i]);
        prefixMax[i] = max;
    }
    var prefixGcd = new long[nums.Length];
    for (int i = 0; i < nums.Length; i++)
        prefixGcd[i] = GCD(prefixMax[i], nums[i]);
    Array.Sort(prefixGcd);
    int li = 0, hi = prefixGcd.Length - 1;
    var res = 0L;
    while (li < hi)
        res += GCD(prefixGcd[li++], prefixGcd[hi--]);
    return res;
}

long GCD(long a, long b)
{
    return a % b == 0 ? b : GCD(b, a % b);
}