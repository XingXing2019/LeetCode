int[] nums = { 0, 1, 1, 1 };
Console.WriteLine(CountAlternatingSubarrays(nums));

long CountAlternatingSubarrays(int[] nums)
{
    int li = 0, hi = 0;
    long res = 0;
    while (hi < nums.Length)
    {
        while (hi < nums.Length && (hi == li || nums[hi] != nums[hi - 1]))
            hi++;
        res += (long)(1 + hi - li) * (hi - li) / 2;
        li = hi;
    }
    return res;
}