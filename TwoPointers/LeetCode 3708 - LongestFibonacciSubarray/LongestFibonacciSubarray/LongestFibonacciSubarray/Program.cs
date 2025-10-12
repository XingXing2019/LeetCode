int[] nums = { 1, 1, 1, 1, 2, 3, 5, 1 };
Console.WriteLine(LongestSubarray(nums));

int LongestSubarray(int[] nums)
{
    int li = 0, hi = 0, res = 0;
    while (hi < nums.Length)
    {
        while (hi - li >= 2 && nums[hi] != nums[hi - 1] + nums[hi - 2])
            li++;
        res = Math.Max(res, hi - li + 1);
        hi++;
    }
    return res;
}