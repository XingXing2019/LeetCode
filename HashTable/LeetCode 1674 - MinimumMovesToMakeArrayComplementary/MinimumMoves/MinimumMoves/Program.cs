int MinMoves(int[] nums, int limit)
{
    var dict = new Dictionary<int, int>();
    for (int i = 0; i < nums.Length / 2; i++)
    {
        int a = Math.Min(nums[i], nums[^(i + 1)]);
        int b = Math.Max(nums[i], nums[^(i + 1)]);
        Record(dict, 2, 2);
        Record(dict, a + 1, -1);
        Record(dict, a + b, -1);
        Record(dict, a + b + 1, 1);
        Record(dict, b + limit + 1, 1);
    }
    dict = dict.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
    int sum = 0, res = int.MaxValue;
    foreach (var key in dict.Keys)
    {
        sum += dict[key];
        res = Math.Min(res, sum);
    }
    return res;
}

void Record(Dictionary<int, int> dict, int key, int value)
{
    if (!dict.ContainsKey(key))
        dict[key] = 0;
    dict[key] += value;
}