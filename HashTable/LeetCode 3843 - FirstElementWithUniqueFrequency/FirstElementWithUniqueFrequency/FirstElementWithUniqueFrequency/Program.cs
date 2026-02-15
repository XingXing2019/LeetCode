int FirstUniqueFreq(int[] nums)
{
    var freq = nums.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
    var uniqueFreq = new HashSet<int>(freq.GroupBy(x => x.Value).Where(x => x.Count() == 1).Select(x => x.Key));
    for (int i = 0; i < nums.Length; i++)
    {
        if (uniqueFreq.Contains(freq[nums[i]]))
            return nums[i];
    }
    return -1;
}