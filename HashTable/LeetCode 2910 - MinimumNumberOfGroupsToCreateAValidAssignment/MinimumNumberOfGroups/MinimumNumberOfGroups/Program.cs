int[] nums = { 1, 1, 1, 1, 1 };
Console.WriteLine(MinGroupsForValidAssignment(nums));
int MinGroupsForValidAssignment(int[] nums)
{
    var freq = nums.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
    int minFreq = freq.Values.Min(), res = int.MaxValue;
    for (int i = 1; i <= minFreq; i++)
    {
        var groups = GetGroups(freq.Values.ToList(), i);
        if (groups == -1) continue;
        res = Math.Min(res, groups);
    }
    return res;
}

int GetGroups(List<int> freqs, int x)
{
    var res = 0;
    foreach (var freq in freqs)
    {
        int mod = freq % (x + 1), count = freq / (x + 1);
        if (mod == 0)
            res += count;
        else if (x <= mod + count)
            res += count + 1;
        else
            return -1;
    }
    return res;
}

