int[] nums = { 8, 6, 1, 5, 3 };
Console.WriteLine(MinimumSum(nums));

int MinimumSum(int[] nums)
{
    var leftMin = new int[nums.Length];
    var rightMin = new int[nums.Length];
    int left = int.MaxValue, right = int.MaxValue, res = int.MaxValue;
    for (int i = 0; i < nums.Length; i++)
    {
        leftMin[i] = left;
        left = Math.Min(left, nums[i]);
        rightMin[^(i + 1)] = right;
        right = Math.Min(right, nums[^(i + 1)]);
    }
    for (int i = 1; i < nums.Length - 1; i++)
    {
        if (leftMin[i] >= nums[i] || rightMin[i] >= nums[i])   
            continue;
        res = Math.Min(res, leftMin[i] + nums[i] + rightMin[i]);
    }
    return res == int.MaxValue ? -1 : res;
}