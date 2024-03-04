int[] nums = { 1, 3 };
int[] changeIndices = { 1, 1, 1, 2, 1, 1, 1 };
Console.WriteLine(EarliestSecondToMarkIndices(nums, changeIndices));

int EarliestSecondToMarkIndices(int[] nums, int[] changeIndices)
{
    int li = 0, hi = changeIndices.Length - 1;
    while (li <= hi)
    {
        var mid = li + (hi - li) / 2;
        if (IsSufficient(nums, changeIndices, mid))
            hi = mid - 1;
        else
            li = mid + 1;
    }
    return li == changeIndices.Length ? -1 : li + 1;
}

bool IsSufficient(int[] nums, int[] changeIndices, int sec)
{
    var lastIndices = new Dictionary<int, int>();
    for (int i = 0; i <= sec; i++)
        lastIndices[changeIndices[i]] = i + 1;
    if (lastIndices.Count != nums.Length)
        return false;
    lastIndices = lastIndices.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
    var count = 0;
    foreach (var index in lastIndices.Keys)
    {
        count += nums[index - 1] + 1;
        if (lastIndices[index] < count)
            return false;
    }
    return true;
}