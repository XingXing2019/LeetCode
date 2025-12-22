int[] nums = { 3, 8, 3, 6, 5, 8 };
Console.WriteLine(MinOperations(nums));

int MinOperations(int[] nums)
{
    var dict = new Dictionary<int, List<int>>();
    var res = 0;
    for (int i = 0; i < nums.Length; i++)
    {
        if (!dict.ContainsKey(nums[i]))
            dict[nums[i]] = new List<int>();
        dict[nums[i]].Add(i);
    }
    foreach (var pos in dict.Values)
    {
        if (pos.Count == 1) continue;
        res = Math.Max(res, pos[^2] / 3 + 1);
    }
    return res;
}