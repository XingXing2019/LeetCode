int MinOperations(int[] nums)
{
    var res = 0;
    for (int i = 0; i < nums.Length; i++)
    {
        if (nums[i] == 0 && res % 2 == 0 || nums[i] == 1 && res % 2 != 0)
            res++;
    }
    return res;
}