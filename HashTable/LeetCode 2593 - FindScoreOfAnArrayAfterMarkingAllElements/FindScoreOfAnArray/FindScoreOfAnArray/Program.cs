int[] nums = { 2, 1, 3, 4, 5, 2 };
Console.WriteLine(FindScore(nums));

long FindScore(int[] nums)
{
    var indexes = new Dictionary<int, HashSet<int>>();
    long res = 0;
    for (int i = 0; i < nums.Length; i++)
    {
        if (!indexes.ContainsKey(nums[i]))
            indexes[nums[i]] = new HashSet<int>();
        indexes[nums[i]].Add(i);
    }
    var keys = indexes.OrderBy(x => x.Key).Select(x => x.Key).ToList();
    foreach (var key in keys)
    {
        foreach (var index in indexes[key])
        {
            res += key;
            int pre = index - 1, next = index + 1;
            if (pre >= 0)
                indexes[nums[pre]].Remove(pre);
            if (next < nums.Length)
                indexes[nums[next]].Remove(next);
        }
    }
    return res;
}