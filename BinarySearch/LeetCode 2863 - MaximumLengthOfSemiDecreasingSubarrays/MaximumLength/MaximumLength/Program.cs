int[] nums = { 7, 6, 5, 4, 3, 2, 1, 6, 10, 11 };
Console.WriteLine(MaxSubarrayLength(nums));

int MaxSubarrayLength(int[] nums)
{
    var suffix = new int[nums.Length];
    int min = nums[^1], res = 0;
    for (int i = nums.Length - 1; i >= 0; i--)
    {
        min = Math.Min(min, nums[i]);
        suffix[i] = min;
    }
    for (int i = 0; i < nums.Length; i++)
        res = Math.Max(res, BinarySearch(suffix, i, nums[i] - 1) - i + 1);
    return res;
}

int BinarySearch(int[] nums, int index, int target)
{
    int li = index, hi = nums.Length - 1;
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