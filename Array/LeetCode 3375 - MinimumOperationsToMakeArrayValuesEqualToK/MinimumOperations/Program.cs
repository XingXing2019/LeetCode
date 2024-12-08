int MinOperations(int[] nums, int k)
{
    Array.Sort(nums);
    if (nums[0] < k) return -1;
    var res = 0;
    for (int i = nums.Length - 2; i >= 0; i--)
    {
        if (nums[i] != nums[i + 1])
            res++;
        if (nums[i] < k)
            return -1;
    }
    return nums[0] == k ? res : res + 1;
}