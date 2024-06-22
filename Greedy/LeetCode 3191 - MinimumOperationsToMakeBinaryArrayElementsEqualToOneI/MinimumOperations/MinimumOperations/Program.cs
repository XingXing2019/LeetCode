int MinOperations(int[] nums)
{
    var res = 0;
    for (int i = 0; i <= nums.Length - 3; i++)
    {
        if (nums[i] == 1) continue;
        nums[i] ^= 1;
        nums[i + 1] ^= 1;
        nums[i + 2] ^= 1;
        res++;
    }
    return nums[^1] == 1 && nums[^2] == 1 ? res : -1;
}