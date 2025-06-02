bool CheckEqualPartitions(int[] nums, long target)
{
    long prod = 1;
    foreach (var num in nums)
    {
        if (num > target) return false;
        prod *= num;
    }
    return prod == target * target;
}