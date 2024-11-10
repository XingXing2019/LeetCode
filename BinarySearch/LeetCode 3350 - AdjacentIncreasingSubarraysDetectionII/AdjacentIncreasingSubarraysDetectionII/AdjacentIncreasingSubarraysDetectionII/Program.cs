int MaxIncreasingSubarrays(IList<int> nums)
{
    var increase = new List<int>();
    var count = 1;
    for (int i = 1; i < nums.Count; i++)
    {
        if (nums[i] > nums[i - 1])
            count++;
        else
        {
            increase.Add(count);
            count = 1;
        }
    }
    increase.Add(count);
    int li = 1, hi = nums.Count / 2;
    while (li <= hi)
    {
        var mid = li + (hi - li) / 2;
        if (IsIncreasing(increase, mid))
            li = mid + 1;
        else
            hi = mid - 1;
    }
    return hi;
}

bool IsIncreasing(List<int> increase, int len)
{
    for (int i = 0; i < increase.Count; i++)
    {
        if (increase[i] >= 2 * len)
            return true;
        if (i != 0 && increase[i] >= len && increase[i - 1] >= len)
            return true;
    }
    return false;
}