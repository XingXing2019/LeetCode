int[] DelayedCount(int[] nums, int k)
{
    var dict = new Dictionary<int, List<int>>();
    for (int i = 0; i < nums.Length; i++)
    {
        if (!dict.ContainsKey(nums[i]))
            dict[nums[i]] = new List<int>();
        dict[nums[i]].Add(i);
    }
    var res = new int[nums.Length];
    for (int i = 0; i < nums.Length; i++)
    {
        var indexes = dict[nums[i]];
        var index = indexes.BinarySearch(i + k + 1);
        if (index < 0) index = ~index;
        res[i] = Math.Max(0, indexes.Count - index);
    }
    return res;
}