int CompareBitonicSums(int[] nums)
{
    long increase = nums[0];
    long decrease = nums.Max();
    for (int i = 1; i < nums.Length; i++)
    {
        if (nums[i] > nums[i - 1])
            increase += nums[i];
        else
            decrease += nums[i];
    }
    return increase > decrease ? 0 : increase < decrease ? 1 : -1;
}