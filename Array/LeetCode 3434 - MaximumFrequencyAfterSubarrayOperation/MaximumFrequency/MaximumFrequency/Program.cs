int MaxFrequency(int[] nums, int k)
{
    var freq = new int[51];
    int res = 0, count = 0;
    foreach (var num in nums)
    {
        freq[num] = Math.Max(freq[num], count) + 1;
        res += num == k ? 1 : 0;
        count += num == k ? 1 : 0;
        res = Math.Max(res, freq[num]);
    }
    return res;
}