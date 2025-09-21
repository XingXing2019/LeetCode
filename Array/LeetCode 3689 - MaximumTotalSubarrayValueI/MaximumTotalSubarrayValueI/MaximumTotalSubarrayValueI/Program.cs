long MaxTotalValue(int[] nums, int k)
{
    long min = int.MaxValue, max = int.MinValue;
    foreach (var num in nums)
    {
        min = Math.Min(min, num);
        max = Math.Max(max, num);
    }
    return (max - min) * k;
}