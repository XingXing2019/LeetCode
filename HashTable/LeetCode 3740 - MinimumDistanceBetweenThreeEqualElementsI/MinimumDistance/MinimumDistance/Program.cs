int MinimumDistance(int[] nums)
{
    var dict = new Dictionary<int, List<int>>();
    for (int i = 0; i < nums.Length; i++)
    {
        if (!dict.ContainsKey(nums[i]))
            dict[nums[i]] = new List<int>();
        dict[nums[i]].Add(i);
    }
    var res = int.MaxValue;
    foreach (var indexes in dict.Values)
    {
        for (int i = 0; i <= indexes.Count - 3; i++)
        {
            res = Math.Min(res, 2 * indexes[i + 2] - 2 * indexes[i]);
        }
    }
    return res == int.MaxValue ? -1 : res;
}