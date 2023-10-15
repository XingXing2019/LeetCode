int[] FindIndices(int[] nums, int indexDifference, int valueDifference)
{
    for (int i = 0; i < nums.Length; i++)
    {
        for (int j = i; j < nums.Length; j++)
        {
            if (Math.Abs(i - j) >= indexDifference && Math.Abs(nums[i] - nums[j]) >= valueDifference)
                return new[] { i, j };
        }
    }
    return new[] { -1, -1 };
}