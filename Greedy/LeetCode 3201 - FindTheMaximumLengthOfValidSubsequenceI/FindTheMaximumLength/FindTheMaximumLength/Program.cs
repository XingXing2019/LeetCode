int MaximumLength(int[] nums)
{
    var len = new int[4];
    int firstEven = -1, firstOdd = -1;
    for (int i = 0; i < nums.Length; i++)
    {
        if (nums[i] % 2 == 0)
        {
            if (firstEven == -1)
                firstEven = i;
            len[0]++;
        }
        else
        {
            if (firstOdd == -1)
                firstOdd = i;
            len[1]++;
        }
    }
    len[2] = GetLength(nums, firstOdd);
    len[3] = GetLength(nums, firstEven);
    return len.Max();
}

int GetLength(int[] nums, int start)
{
    if (start == -1) return 0;
    int res = 1, last = nums[start];
    for (int i = start + 1; i < nums.Length; i++)
    {
        if (last % 2 != nums[i] % 2)
        {
            res++;
            last = nums[i];
        }
    }
    return res;
}