int MaximizeExpressionOfThree(int[] nums)
{
    Array.Sort(nums);
    return nums[^1] + nums[^2] - nums[0];
}