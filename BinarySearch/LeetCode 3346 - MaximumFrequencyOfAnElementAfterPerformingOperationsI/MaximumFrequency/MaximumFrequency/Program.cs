int[] nums = { 1, 4, 5 };
int k = 1, numOperations = 2;
Console.WriteLine(MaxFrequency(nums, k, numOperations));

int MaxFrequency(int[] nums, int k, int numOperations)
{
    var freq = nums.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
    if (k == 0 || numOperations == 0)
        return freq.Max(x => x.Value);
    Array.Sort(nums);
    var res = 0;
    for (int i = 0; i < nums[^1] + k; i++)
    {
        var right = BinarySearch(nums, i + k, true);
        var left = BinarySearch(nums, i - k, false);
        var count = Math.Min(right - left + 1 - freq.GetValueOrDefault(i, 0), numOperations);
        res = Math.Max(res, count + freq.GetValueOrDefault(i, 0));
    }
    return res;
}

int BinarySearch(int[] nums, int target, bool isRight)
{
    int li = 0, hi = nums.Length - 1;
    while (li <= hi)
    {
        var mid = li + (hi - li) / 2;
        if (isRight)
        {
            if (nums[mid] <= target)
                li = mid + 1;
            else
                hi = mid - 1;
        }
        else
        {
            if (nums[mid] < target)
                li = mid + 1;
            else
                hi = mid - 1;
        }
    }
    return isRight ? hi : li;
}