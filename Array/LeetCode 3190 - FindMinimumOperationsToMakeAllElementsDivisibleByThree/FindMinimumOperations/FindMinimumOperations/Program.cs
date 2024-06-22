int MinimumOperations(int[] nums)
{
    return nums.Sum(x => Math.Min(x % 3, 3 - x % 3));
}