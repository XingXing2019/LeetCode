int CountPartitions(int[] nums)
{
    for (int i = 1; i < nums.Length; i++)
        nums[i] += nums[i - 1];
    var res = 0;
    for (int i = 0; i < nums.Length - 1; i++)
    {
        var diff = nums[i] - (nums[^1] - nums[i]);
        if (diff % 2 == 0)
            res++;
    }
    return res;
}