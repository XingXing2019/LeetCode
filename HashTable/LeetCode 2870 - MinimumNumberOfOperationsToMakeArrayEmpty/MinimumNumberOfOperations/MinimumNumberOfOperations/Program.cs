int MinOperations(int[] nums)
{
    var freq = nums.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
    var res = 0;
    foreach (var num in freq.Keys)
    {
        if (freq[num] == 1)
            return -1;
        res += freq[num] % 3 == 0 ? freq[num] / 3 : freq[num] / 3 + 1;
    }
    return res;
}