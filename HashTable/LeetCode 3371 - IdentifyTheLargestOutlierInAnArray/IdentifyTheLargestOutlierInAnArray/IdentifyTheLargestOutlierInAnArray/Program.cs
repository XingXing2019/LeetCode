int GetLargestOutlier(int[] nums)
{
    var freq = nums.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
    var sum = nums.Sum();
    var res = int.MinValue;
    foreach (var num in nums)
    {
        var left = sum - num;
        if (left % 2 != 0 || !freq.ContainsKey(left / 2)) continue;
        if (left / 2 == num && freq[num] == 1) continue;
        res = Math.Max(res, num);
    }
    return res;
}