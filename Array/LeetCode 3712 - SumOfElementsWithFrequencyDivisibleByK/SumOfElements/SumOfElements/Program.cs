int SumDivisibleByK(int[] nums, int k)
{
    var res = 0;
    var freq = nums.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
    foreach (var num in freq.Keys)
    {
        if (freq[num] % k != 0) continue;
        res += num * freq[num];
    }
    return res;
}