int[] ConstructTransformedArray(int[] nums)
{
    var res = new int[nums.Length];
    for (int i = 0; i < res.Length; i++)
    {
        int index = i, len = nums.Length, abs = Math.Abs(nums[i]) % len;
        if (nums[i] < 0)
            index = (i - abs + len) % len;
        else if (nums[i] > 0)
            index = (i + abs) % len;
        res[i] = nums[index];
    }
    return res;
}