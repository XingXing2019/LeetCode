int MinimumCost(int[] nums)
{
    int min = int.MaxValue, sum = int.MaxValue;
    var rightMin = new int[nums.Length];
    for (int i = nums.Length - 1; i >= 0; i--)
    {
        rightMin[i] = min;
        min = Math.Min(min, nums[i]);
    }
    for (int i = 1; i < nums.Length - 1; i++)
        sum = Math.Min(sum, nums[i] + rightMin[i]);
    return nums[0] + sum;
}