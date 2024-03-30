int MinimumSubarrayLength(int[] nums, int k)
{
    var res = int.MaxValue;
    for (int i = 0; i < nums.Length; i++)
    {
        var or = 0;
        for (int j = i; j < nums.Length; j++)
        {
            or |= nums[j];
            if (or >= k)
            {
                res = Math.Min(res, j - i + 1);
                break;
            }
        }
    }
    return res == int.MaxValue ? -1 : res;
}