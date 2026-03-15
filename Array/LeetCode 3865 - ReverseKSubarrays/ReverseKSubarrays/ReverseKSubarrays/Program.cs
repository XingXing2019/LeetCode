int[] ReverseSubarrays(int[] nums, int k)
{
    var size = nums.Length / k;
    for (int i = 0; i < nums.Length; i += size)
    {
        int li = i, hi = i + size - 1;
        while (li < hi)
        {
            (nums[li], nums[hi]) = (nums[hi++], nums[li--]);
        }
    }
    return nums;
}