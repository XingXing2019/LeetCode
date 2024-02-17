int MaxOperations(int[] nums)
{
    int res = 1, sum = nums[0] + nums[1];
    for (int i = 3; i < nums.Length; i+=2)
    {
        if (nums[i] + nums[i - 1] == sum)
            res++;
        else
            return res;
    }
    return res;
}