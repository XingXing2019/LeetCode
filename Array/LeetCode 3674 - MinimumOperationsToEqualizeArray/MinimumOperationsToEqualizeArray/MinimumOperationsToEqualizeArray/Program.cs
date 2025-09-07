int minOperations(int[] nums)
{
    return nums.All(x => x == nums[0]) ? 0 : 1;
}