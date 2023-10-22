int MinimumSum(int[] nums)
{
    var res = int.MaxValue;
    for (int i = 1; i < nums.Length - 1; i++)
    {
        int leftMin = int.MaxValue, rightMin = int.MaxValue;
        for (int j = 0; j < i; j++)
            leftMin = Math.Min(leftMin, nums[j]);
        for (int j = i + 1; j < nums.Length; j++)
            rightMin = Math.Min(rightMin, nums[j]);
        if (leftMin >= nums[i] || rightMin >= nums[i])
            continue;
        res = Math.Min(res, leftMin + nums[i] + rightMin);
    }
    return res == int.MaxValue ? -1 : res;
}