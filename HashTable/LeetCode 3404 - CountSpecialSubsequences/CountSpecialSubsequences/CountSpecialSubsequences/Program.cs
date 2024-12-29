long NumberOfSubsequences(int[] nums)
{
    var freq = new Dictionary<double, long>();
    var res = 0L;
    for (int r = 3; r < nums.Length - 2; r++)
    {
        var q = r - 2;
        for (int p = 0; p < q - 1; p++)
        {
            var ratio = (double)nums[p] / nums[q];
            freq[ratio] = freq.GetValueOrDefault(ratio, 0) + 1;
        }
        for (int s = r + 2; s < nums.Length; s++)
        {
            var ratio = (double)nums[s] / nums[r];
            res += freq.GetValueOrDefault(ratio, 0);
        }
    }
    return res;
}