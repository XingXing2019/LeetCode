int[] nums = { 1, 2, 4, 4, 3 };
Console.WriteLine(SplitArray(nums));

long SplitArray(int[] nums)
{
    int max = 0, index = 0;
    for (int i = 0; i < nums.Length; i++)
    {
        if (nums[i] <= max) continue;
        max = nums[i];
        index = i;
    }
    var count = nums.Count(x => x == max);
    if (count > 2) return -1;
    var res = 0L;
    for (int i = 0; i < nums.Length; i++)
    {
        if (i < index)
        {
            if (i != 0 && nums[i] <= nums[i - 1])
                return -1;
            res += nums[i];
        }
        else if (i > index)
        {
            if (i != index + 1 && nums[i] >= nums[i - 1])
                return -1;
            res -= nums[i];
        }
    }
    if (count == 2) return Math.Abs(res + max);
    return Math.Min(Math.Abs(res + max), Math.Abs(res - max));
}