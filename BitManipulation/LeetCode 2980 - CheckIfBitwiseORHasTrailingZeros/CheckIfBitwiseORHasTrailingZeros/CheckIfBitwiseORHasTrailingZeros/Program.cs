bool HasTrailingZeros(int[] nums)
{
    return nums.Count(x => (x & 1) == 0) > 1;
}