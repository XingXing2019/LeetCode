int[] nums = { -3, 2, -1, 4 };
Console.WriteLine(PerfectPairs(nums));

long PerfectPairs(int[] nums)
{
    nums = nums.Select(x => Math.Abs(x)).OrderBy(x => x).ToArray();
    var res = 0L;
    for (int i = 0; i < nums.Length; i++)
    {
        var hi = BinarySearch(nums, nums[i] * 2);
        if (hi == i) continue;
        res += hi - i;
    }
    return res;
}

int BinarySearch(int[] nums, int target)
{
    int li = 0, hi = nums.Length - 1;
    while (li <= hi)
    {
        var mid = li + (hi - li) / 2;
        if (nums[mid] <= target)
            li = mid + 1;
        else
            hi = mid - 1;
    }
    return hi;
}