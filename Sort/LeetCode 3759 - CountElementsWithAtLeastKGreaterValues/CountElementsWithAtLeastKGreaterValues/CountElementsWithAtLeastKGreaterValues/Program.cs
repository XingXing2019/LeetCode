int CountElements(int[] nums, int k)
{
    if (k == 0) return nums.Length;
    Array.Sort(nums);
    var target = nums[^k];
    var res = 0;
    foreach (var num in nums)
    {
        if (num < target)
            res++;
    }
    return res;
}