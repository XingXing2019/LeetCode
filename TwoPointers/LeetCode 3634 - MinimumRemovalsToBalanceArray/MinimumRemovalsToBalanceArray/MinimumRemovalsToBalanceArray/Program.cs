int[] nums = { 2, 1, 5 };
var k = 2;
Console.WriteLine(MinRemoval(nums, k));

int MinRemoval(int[] nums, int k)
{
    Array.Sort(nums);
    var res = int.MaxValue;
    for (int i = 0; i < nums.Length; i++)
    {
        var hi = BinarySearch(nums, (long)nums[i] * k);
        res = Math.Min(res, nums.Length - (hi - i + 1));
    }
    return res;
}

int BinarySearch(int[] nums, long target)
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