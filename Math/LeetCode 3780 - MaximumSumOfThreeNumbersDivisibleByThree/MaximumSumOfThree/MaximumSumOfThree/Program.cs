int[] nums = { 4, 9, 4, 4, 5, 6, 9 };
Console.WriteLine(MaximumSum(nums));

int MaximumSum(int[] nums)
{
    var res = 0;
    var dict = new Dictionary<int, List<int>>();
    foreach (var num in nums)
    {
        if (!dict.ContainsKey(num % 3))
            dict[num % 3] = new List<int>();
        dict[num % 3].Add(num);
    }
    foreach (var value in dict.Values)
        value.Sort();
    for (int i = 0; i < 3; i++)
    {
        if (dict.ContainsKey(i) && dict[i].Count > 2)
            res = Math.Max(res, dict[i][^1] + dict[i][^2] + dict[i][^3]);
    }
    if (dict.ContainsKey(0) && dict.ContainsKey(1) && dict.ContainsKey(2))
        res = Math.Max(res, dict[0][^1] + dict[1][^1] + dict[2][^1]);
    return res;
}