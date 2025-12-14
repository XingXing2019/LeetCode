int AbsDifference(int[] nums, int k)
{
    Array.Sort(nums);
    var res = 0;
    for (int i = 0; i < k; i++)
        res += nums[i] - nums[^(i + 1)];
    return Math.Abs(res);
}