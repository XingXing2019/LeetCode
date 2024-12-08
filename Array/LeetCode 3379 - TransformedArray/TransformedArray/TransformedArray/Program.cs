int[] ConstructTransformedArray(int[] nums)
{
    var res = new int[nums.Length];
    for (int i = 0; i < res.Length; i++)
    {
        var index = i;
        var abs = Math.Abs(nums[i]) % nums.Length;
        if (nums[i] < 0)
            index = (i - abs + nums.Length) % nums.Length;
        else if (nums[i] > 0)
            index = (i + abs) % nums.Length;
        res[i] = nums[index];
    }
    return res;
}