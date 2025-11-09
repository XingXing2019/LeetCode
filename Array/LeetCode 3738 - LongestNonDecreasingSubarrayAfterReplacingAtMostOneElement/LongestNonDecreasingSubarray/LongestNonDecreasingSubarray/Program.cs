int[] nums = { 4 };
Console.WriteLine(LongestSubarray(nums));
int LongestSubarray(int[] nums)
{
    var left = new int[nums.Length];
    var right = new int[nums.Length];
    int l = 0, r = 0, res = 0;
    for (int i = 0; i < nums.Length; i++)
    {
        l = i == 0 ? 1 : nums[i] >= nums[i - 1] ? l + 1 : 1;
        left[i] = l;
        r = i == 0 ? 1 : nums[^(i + 1)] <= nums[^i] ? r + 1 : 1;
        right[^(i + 1)] = r;
    }
    for (int i = 0; i < nums.Length; i++)
    {
        if (i != 0)
            res = Math.Max(res, left[i - 1] + 1);
        if (i != nums.Length - 1)
            res = Math.Max(res, right[i + 1] + 1);
        if (i != 0 && i != nums.Length - 1 && nums[i - 1] <= nums[i + 1])
            res = Math.Max(res, left[i - 1] + right[i + 1] + 1);
    }
    return res;
}