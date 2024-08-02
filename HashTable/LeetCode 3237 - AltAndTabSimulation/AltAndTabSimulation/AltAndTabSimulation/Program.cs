int[] SimulationResult(int[] windows, int[] queries)
{
    var nums = new List<int>();
    var dict = new Dictionary<int, int>();
    for (int i = windows.Length - 1; i >= 0; i--)
    {
        dict[windows[i]] = nums.Count;
        nums.Add(windows[i]);
    }
    foreach (var query in queries)
    {
        var pos = dict[query];
        nums[pos] = -1;
        dict[query] = nums.Count;
        nums.Add(query);
    }
    var res = new int[windows.Length];
    var index = 0;
    for (int i = nums.Count - 1; i >= 0; i--)
    {
        if (nums[i] == -1) continue;
        res[index++] = nums[i];
    }
    return res;
}