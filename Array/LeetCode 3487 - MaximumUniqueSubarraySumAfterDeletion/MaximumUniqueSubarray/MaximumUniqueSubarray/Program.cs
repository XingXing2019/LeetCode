int MaxSum(int[] nums)
{
    if (nums.Length == 1) return nums[0];
    return new HashSet<int>(nums.Where(x => x > 0)).Sum();
}