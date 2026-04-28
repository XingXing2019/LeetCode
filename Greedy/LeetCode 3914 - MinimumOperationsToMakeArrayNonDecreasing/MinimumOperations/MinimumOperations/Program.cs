long MinOperations(int[] nums)
{
    var res = 0L;
    var increase = 0;
    for (int i = 1; i < nums.Length; i++)
    {
        nums[i] += increase;
        var diff = Math.Max(0, nums[i - 1] - nums[i]);
        res += diff;
        increase += diff;
        nums[i] += diff;
    }
    return res;
}