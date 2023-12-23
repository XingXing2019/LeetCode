long LargestPerimeter(int[] nums)
{
    Array.Sort(nums);
    var prefix = new long[nums.Length];
    for (int i = 0; i < nums.Length; i++)
        prefix[i] = i == 0 ? nums[i] : nums[i] + prefix[i - 1];
    for (int i = nums.Length - 1; i >= 2; i--)
    {
        if (nums[i] >= prefix[i - 1]) continue;
        return prefix[i];
    }
    return -1;
}