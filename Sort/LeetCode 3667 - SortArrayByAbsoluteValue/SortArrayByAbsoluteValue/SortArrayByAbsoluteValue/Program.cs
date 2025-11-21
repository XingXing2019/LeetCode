int[] SortByAbsoluteValue(int[] nums)
{
    return nums.OrderBy(x => Math.Abs(x)).ToArray();
}